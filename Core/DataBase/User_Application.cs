//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class User_Application
    {
        public int ID { get; set; }
        public Nullable<int> IDUser { get; set; }
        public Nullable<int> IDApplication { get; set; }
        public Nullable<bool> UserRespond { get; set; }
        public Nullable<bool> ApplicationRespond { get; set; }
    
        public virtual Applictioon Applictioon { get; set; }
        public virtual User User { get; set; }
    }
}
