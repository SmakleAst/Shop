using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Enums
{
    public enum Statuses
    {
        [Display(Name = "Новый")]
        New = 0,

        [Display(Name = "В обработке")]
        InProcessing = 1,

        [Display(Name = "Отправлен")]
        Sent = 2,
    }
}
