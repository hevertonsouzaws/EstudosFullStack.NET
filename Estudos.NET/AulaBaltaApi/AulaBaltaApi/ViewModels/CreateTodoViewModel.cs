using System.ComponentModel.DataAnnotations;

namespace AulaBaltaApi.ViewModels
{
    public class CreateTodoViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}
