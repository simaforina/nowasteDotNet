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
    
    public partial class Requests
    {
        public System.Guid id { get; set; }
        public System.Guid clientPersonID { get; set; }
        public System.DateTime requestDate { get; set; }
        public Nullable<System.DateTime> takeOutDate { get; set; }
        public Nullable<int> recycleResoursesID { get; set; }
        public Nullable<decimal> recycleResoursesWeight { get; set; }
        public Nullable<System.Guid> managerID { get; set; }
        public Nullable<int> statusID { get; set; }
        public string comments { get; set; }
        public Nullable<int> cityID { get; set; }
        public Nullable<int> cityDistrictID { get; set; }
        public Nullable<System.Guid> executorID { get; set; }
        public string takeOutAddress { get; set; }
        public Nullable<System.Guid> companyID { get; set; }
    
        public virtual Cities Cities { get; set; }
        public virtual CityDistricts CityDistricts { get; set; }
        public virtual ClientPersons ClientPersons { get; set; }
        public virtual Companies Companies { get; set; }
        public virtual Emploees Emploees { get; set; }
        public virtual Emploees Emploees1 { get; set; }
        public virtual RecycledResourses RecycledResourses { get; set; }
        public virtual RequestStatuses RequestStatuses { get; set; }
    }
}
