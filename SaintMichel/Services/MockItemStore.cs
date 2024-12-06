
namespace SaintMichel.Services
{
    public class MockItemStore : IitemStore<ToDoList>
    {
        readonly List<ToDoList> LsToDoList;

        public MockItemStore()
        {
            LsToDoList = new List<ToDoList>()
            {
                new ToDoList { Id = Guid.NewGuid().ToString(), Title = "Go to the doctor", Description ="Its near Annecy center to get an appoinment", IsDone= true },
                new ToDoList { Id = Guid.NewGuid().ToString(), Title = "Watch Netflix", Description ="To get to know new series", IsDone= true },
                new ToDoList { Id = Guid.NewGuid().ToString(), Title = "Insta Post", Description ="Creat content with canva daily", IsDone= false },
                new ToDoList { Id = Guid.NewGuid().ToString(), Title = "Bring Groceries", Description ="Bring Groceries from the supermarket to home", IsDone= true},
                new ToDoList { Id = Guid.NewGuid().ToString(), Title = "Reas Something", Description ="Make a habit of reading", IsDone= false },
                new ToDoList { Id = Guid.NewGuid().ToString(), Title = "Email reply ", Description ="Give reply to all friends", IsDone= true }
            };
        }

        public async Task<bool> AddItemAsync(ToDoList todolist)
        {
            LsToDoList.Add(todolist);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ToDoList todolist)
        {
            var OldToDoList = LsToDoList.Where((ToDoList arg) => arg.Id == todolist.Id).FirstOrDefault();
            LsToDoList.Remove(OldToDoList);
            LsToDoList.Add(todolist);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var OldToDoList = LsToDoList.Where((ToDoList arg) => arg.Id == id).FirstOrDefault();
            LsToDoList.Remove(OldToDoList);

            return await Task.FromResult(true);
        }

        public async Task<ToDoList> GetItemAsync(string id)
        {
            return await Task.FromResult(LsToDoList.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ToDoList>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(LsToDoList);
        }
    }
}