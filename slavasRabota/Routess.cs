//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace slavasRabota
{
    using System;
    using System.Collections.Generic;
    
    public partial class Routess
    {
        public int ID_Route { get; set; }
        public int Order_ID { get; set; }
        public string Otpravlenie { get; set; }
        public string Dostavka { get; set; }
        public Nullable<int> Protyajonnost { get; set; }
        public int Transport_ID { get; set; }
        public int RouteStatus_ID { get; set; }
    
        public virtual Orders Orders { get; set; }
        public virtual RouteStatuses RouteStatuses { get; set; }
        public virtual Transport Transport { get; set; }
    }
}
