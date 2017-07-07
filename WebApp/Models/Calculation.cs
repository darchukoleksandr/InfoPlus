using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    /// <summary>
    /// Модель, отображающая вычисления
    /// </summary>
    public class Calculation
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Логин для которого велись вычисления
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Выражение 
        /// </summary>
        public string Expression { get; set; }
        /// <summary>
        /// Результат выражения
        /// </summary>
        public string Result { get; set; }
    }
}
