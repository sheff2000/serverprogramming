/*
*  тут клепаем "модели" - типа создаем класс со свойствами
*  свойства - это наши столбцы в таблице (повторяем структуру таблицы)
*  в итоге получаем типа "снимок" структуры нашей в талице, но уже ввиде класса
*/

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApiApp.Models
{
    [Table("Users")]
    public class UsersTable
    {
        [Key]
        public int user_id { get; set; }
        public string? user_login { get; set; }
        public string? user_password { get; set; }
        public string? user_info { get; set; }
    }
}
