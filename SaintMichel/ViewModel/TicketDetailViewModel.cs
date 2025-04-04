
using System.Windows.Input;


public class TicketDetailViewModel : BaseViewModel
{
    public Ticket Ticket { get; set; }
    public ICommand ToggleStatusCommand { get; set; }
    public ICommand SendMessageCommand { get; set; }
    public ICommand RefreshMessagesCommand { get; set; }

    public string Title => Ticket.titre;
    public string Description => Ticket.description;

    public string Status => Ticket.status == 0 ? "Open" : "Closed";
    public string StatusColor => Ticket.status == 0 ? "Green" : "Red";

    private string _newMessage;
    public string NewMessage
    {
        get => _newMessage;
        set => SetProperty(ref _newMessage, value);
    }

    private ObservableCollection<Message> _messages;
    public ObservableCollection<Message> Messages
    {
        get => _messages;
        set => SetProperty(ref _messages, value);
    }

    private bool _isRefreshing;
    public bool IsRefreshing
    {
        get => _isRefreshing;
        set => SetProperty(ref _isRefreshing, value);
    }

    private readonly TicketApi _ticketApi;
    private readonly MessageApi _messageApi;
    private readonly string _supportName;

    public TicketDetailViewModel(Ticket ticket)
    {
        Ticket = ticket;
        _ticketApi = new TicketApi();
        _messageApi = new MessageApi();
        _supportName = "Support"; // À remplacer par le nom réel du support

        Messages = new ObservableCollection<Message>();

        ToggleStatusCommand = new Command(ToggleStatus);
        SendMessageCommand = new Command(SendMessage, CanSendMessage);
        RefreshMessagesCommand = new Command(LoadMessages);

        // Charger les messages au démarrage
        LoadMessages();

        // Configurer un timer pour rafraîchir les messages périodiquement (toutes les 30 secondes)
        Device.StartTimer(TimeSpan.FromSeconds(30), () =>
        {
            LoadMessages();
            return true; // Continuer le timer
        });
    }

    private async void ToggleStatus()
    {
        Ticket.status = Ticket.status == 0 ? 1 : 0;

        bool success = await _ticketApi.UpdateTicketAsync(Ticket);

        if (success)
        {
            OnPropertyChanged(nameof(Status));
            OnPropertyChanged(nameof(StatusColor));
            await Application.Current.MainPage.DisplayAlert(
                "Status Updated",
                "The ticket status has been updated successfully.",
                "OK"
            );

            // Ajouter un message système pour informer du changement de statut
            var statusMessage = new Message
            {
                ticket_id = Ticket.id_ticket,
                content = $"Le statut du ticket a été changé à '{Status}'",
                timestamp = DateTime.Now,
                is_support = true,
                sender_name = "Système"
            };

            await _messageApi.SendMessageAsync(statusMessage);
            LoadMessages(); // Recharger les messages pour afficher le message système
        }
        else
        {
            Ticket.status = Ticket.status == 0 ? 1 : 0;
            await Application.Current.MainPage.DisplayAlert(
                "Error",
                "Failed to update the ticket status.",
                "OK"
            );
        }
    }

    private async void LoadMessages()
    {
        try
        {
            IsRefreshing = true;

            var messages = await _messageApi.GetTicketMessagesAsync(Ticket.id_ticket);

            // Mettre à jour la collection de messages
            Device.BeginInvokeOnMainThread(() =>
            {
                Messages.Clear();
                foreach (var message in messages.OrderBy(m => m.timestamp))
                {
                    Messages.Add(message);
                }
            });
        }
        catch (Exception ex)
        {
            // Gérer l'erreur
            Debug.WriteLine($"Erreur lors du chargement des messages: {ex.Message}");
        }
        finally
        {
            IsRefreshing = false;
        }
    }

    private bool CanSendMessage()
    {
        return !string.IsNullOrWhiteSpace(NewMessage);
    }

    private async void SendMessage()
    {
        if (string.IsNullOrWhiteSpace(NewMessage))
            return;

        try
        {
            var message = new Message
            {
                ticket_id = Ticket.id_ticket,
                content = NewMessage,
                timestamp = DateTime.Now,
                is_support = true, // Message envoyé par le support
                sender_name = _supportName
            };

            // Ajouter le message localement d'abord pour une UI réactive
            Messages.Add(message);

            // Effacer le champ de saisie
            string sentMessage = NewMessage;
            NewMessage = string.Empty;

            // Envoyer le message à l'API
            bool success = await _messageApi.SendMessageAsync(message);

            if (!success)
            {
                // Si l'envoi échoue, informer l'utilisateur
                await Application.Current.MainPage.DisplayAlert(
                    "Erreur",
                    "Impossible d'envoyer le message. Veuillez réessayer.",
                    "OK"
                );

                // Recharger les messages pour s'assurer que l'UI est synchronisée
                LoadMessages();
            }
            else
            {
                // Journaliser le message envoyé (pour compatibilité avec l'ancien code)
                Console.WriteLine($"Response sent: {sentMessage}");
            }
        }
        catch (Exception ex)
        {
            // Gérer l'erreur
            await Application.Current.MainPage.DisplayAlert(
                "Erreur",
                $"Une erreur s'est produite: {ex.Message}",
                "OK"
            );
        }
    }
}