//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nowaste.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Emploees
    {
        public Emploees()
        {
            this.Requests = new HashSet<Requests>();
            this.Requests1 = new HashSet<Requests>();
        }
    
        public System.Guid id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string position { get; set; }
        public string phoneCode { get; set; }
        public string phoneNumber { get; set; }
    
        public virtual ICollection<Requests> Requests { get; set; }
        public virtual ICollection<Requests> Requests1 { get; set; }
    }
}