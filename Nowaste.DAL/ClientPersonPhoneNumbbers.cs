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
    
    public partial class ClientPersonPhoneNumbbers
    {
        public System.Guid id { get; set; }
        public System.Guid ClientPersonID { get; set; }
        public string operatorCode { get; set; }
        public string phoneNum { get; set; }
    
        public virtual ClientPersons ClientPersons { get; set; }
    }
}
