//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace My_sklad_app.AppDataFiles
{
    using System;
    using System.Collections.Generic;
    
    public partial class prodanniy_tovar
    {
        public int id_prodanniy_tovar { get; set; }
        public string name { get; set; }
        public Nullable<int> count { get; set; }
        public Nullable<int> id_klient { get; set; }
        public Nullable<System.DateTime> date_prodazhi { get; set; }
        public string perevozchik { get; set; }
        public Nullable<float> sum { get; set; }
        public Nullable<int> id_tovarnoy_nakladnoy { get; set; }
        public Nullable<int> id_postavlenniy_tovar { get; set; }
        public Nullable<float> price_one { get; set; }
    
        public virtual klients klients { get; set; }
        public virtual postavlenniy_tovar postavlenniy_tovar { get; set; }
    }
}
