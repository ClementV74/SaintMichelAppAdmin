using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using SaintMichel.Model;

namespace SaintMichel.ViewModel
{
    [QueryProperty(nameof(TicketId), nameof(TicketId))]
    public partial class TicketDetailViewModel : BaseViewModel
    {
        private readonly TicketApi _ticketApi;
        // Propriétés
        [ObservableProperty]
        private string ticketId;
        [ObservableProperty]
        private Ticket currentTicket;
        [ObservableProperty]
        private ObservableCollection<Message> messages = new();
        [ObservableProperty]
        private string newMessage = string.Empty;
        [ObservableProperty]
        private bool isRefreshing;
        [ObservableProperty]
        private bool isSaving;
        [ObservableProperty]
        private bool isTicketFound = true;
        public TicketDetailViewModel(TicketApi ticketApi)
        {
            _ticketApi = ticketApi;
            CurrentTicket = new Ticket(); // Initialiser avec un ticket vide
            Debug.WriteLine("TicketDetailViewModel constructor called");
        }

        // Constructeur par défaut pour le designer
        public TicketDetailViewModel() : this(new TicketApi())
        {
        }
        partial void OnTicketIdChanged(string value)
        {
            Debug.WriteLine($"TicketId changed to: {value}");
            if (!string.IsNullOrEmpty(value))
            {
                LoadTicketAsync(value);
            }
        }
        private async void LoadTicketAsync(string id)
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                Debug.WriteLine($"Loading ticket with ID: {id}");

                // Charger les données du ticket depuis l'API
                var ticket = await _ticketApi.GetTicketAsync(id);

                if (ticket != null)
                {
                    Debug.WriteLine($"Ticket loaded successfully: {ticket.titre}");
                    CurrentTicket = ticket;
                    IsTicketFound = true;

                    // Charger les messages
                    await LoadMessagesAsync();
                }
                else
                {
                    Debug.WriteLine("Ticket not found");
                    IsTicketFound = false;

                    // Créer un ticket par défaut pour éviter les erreurs d'affichage
                    CurrentTicket = new Ticket
                    {
                        id_ticket = int.TryParse(id, out int ticketIdInt) ? ticketIdInt : 0,
                        titre = "Ticket non trouvé",
                        description = "Impossible de charger les détails de ce ticket.",
                        status = 1
                    };

                    await Shell.Current.DisplayAlert("Erreur", "Ticket non trouvé. Vérifiez l'ID du ticket et votre connexion réseau.", "OK");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading ticket: {ex.Message}");
                Debug.WriteLine($"Stack trace: {ex.StackTrace}");

                IsTicketFound = false;
                CurrentTicket = new Ticket
                {
                    id_ticket = int.TryParse(id, out int ticketIdInt) ? ticketIdInt : 0,
                    titre = "Erreur",
                    description = $"Une erreur s'est produite: {ex.Message}",
                    status = 1
                };

                await Shell.Current.DisplayAlert("Erreur", $"Impossible de charger les détails du ticket: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async Task LoadMessagesAsync()
        {
            try
            {
                // Ici, vous devriez charger les messages depuis votre API
                // Pour l'instant, nous utilisons des données simulées
                Messages.Clear();

                // Ajouter des messages de test uniquement si le ticket est valide
                if (CurrentTicket != null && CurrentTicket.id_ticket > 0)
                {
                    Messages.Add(new Message
                    {
                        Id = 1,
                        TicketId = CurrentTicket.id_ticket,
                        SenderId = 1,
                        SenderName = "Jean Dupont",
                        Content = "Bonjour, j'ai un problème avec mon application.",
                        Timestamp = DateTime.Now.AddHours(-2),
                        IsFromCurrentUser = true
                    });

                    Messages.Add(new Message
                    {
                        Id = 2,
                        TicketId = CurrentTicket.id_ticket,
                        SenderId = 2,
                        SenderName = "Support Technique",
                        Content = "Bonjour, pouvez-vous me donner plus de détails?",
                        Timestamp = DateTime.Now.AddHours(-1),
                        IsFromCurrentUser = false
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading messages: {ex.Message}");
            }
        }

        [RelayCommand]
        private async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task ToggleStatusAsync()
        {
            try
            {
                if (CurrentTicket == null || CurrentTicket.id_ticket <= 0)
                {
                    await Shell.Current.DisplayAlert("Erreur", "Ticket invalide ou non chargé.", "OK");
                    return;
                }

                IsSaving = true;

                // Inverser le statut (1 = En cours, 2 = Fermé)
                int oldStatus = CurrentTicket.status;
                CurrentTicket.status = CurrentTicket.status == 1 ? 2 : 1;

                // Sauvegarder le changement via l'API
                bool success = await _ticketApi.UpdateTicketAsync(CurrentTicket);

                if (success)
                {
                    // Afficher un message de confirmation
                    await Shell.Current.DisplayAlert("Succès", $"Le statut du ticket a été changé.", "OK");

                    // Ajouter un message système dans la conversation
                    Messages.Add(new Message
                    {
                        Id = Messages.Count + 1,
                        TicketId = CurrentTicket.id_ticket,
                        SenderId = 0, // ID système
                        SenderName = "Système",
                        Content = $"Le statut du ticket a été changé.",
                        Timestamp = DateTime.Now,
                        IsFromCurrentUser = false
                    });
                }
                else
                {
                    // En cas d'échec, rétablir le statut précédent
                    CurrentTicket.status = oldStatus;
                    await Shell.Current.DisplayAlert("Erreur", "Impossible de mettre à jour le statut du ticket.", "OK");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error updating status: {ex.Message}");
                await Shell.Current.DisplayAlert("Erreur", $"Une erreur s'est produite lors de la mise à jour du statut: {ex.Message}", "OK");
            }
            finally
            {
                IsSaving = false;
            }
        }

        [RelayCommand]
        private async Task SendMessageAsync()
        {
            if (string.IsNullOrWhiteSpace(NewMessage))
                return;

            try
            {
                // Créer le nouveau message
                var message = new Message
                {
                    Id = Messages.Count + 1,
                    TicketId = CurrentTicket.id_ticket,
                    SenderId = 1, // ID de l'utilisateur actuel
                    SenderName = "Jean Dupont", // Nom de l'utilisateur actuel
                    Content = NewMessage,
                    Timestamp = DateTime.Now,
                    IsFromCurrentUser = true
                };

                // Ici, vous devriez sauvegarder le message via votre API
                // Pour l'instant, nous l'ajoutons simplement à la collection
                Messages.Add(message);

                // Effacer le champ de saisie
                NewMessage = string.Empty;

                // Simuler une réponse du support
                await Task.Delay(2000);

                // Créer la réponse
                var response = new Message
                {
                    Id = Messages.Count + 1,
                    TicketId = CurrentTicket.id_ticket,
                    SenderId = 2, // ID du support
                    SenderName = "Support Technique",
                    Content = "Merci pour ces informations. Nous allons examiner votre problème et revenir vers vous dès que possible.",
                    Timestamp = DateTime.Now,
                    IsFromCurrentUser = false
                };

                // Ajouter la réponse à la collection
                Messages.Add(response);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error sending message: {ex.Message}");
                await Shell.Current.DisplayAlert("Erreur", "Une erreur s'est produite lors de l'envoi du message.", "OK");
            }
        }

        [RelayCommand]
        private async Task RefreshAsync()
        {
            IsRefreshing = true;
            await LoadMessagesAsync();
            IsRefreshing = false;
        }
    }
}