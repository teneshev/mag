//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mag
{
    using System;
    using System.Collections.Generic;
    
    public partial class Заказ
    {
        public int id_заказ { get; set; }
        public Nullable<int> id_клиента { get; set; }
        public Nullable<int> id_товара { get; set; }
        public Nullable<System.DateTime> дата_покупки { get; set; }
        public Nullable<int> количество { get; set; }
        public Nullable<double> скидка { get; set; }
        public Nullable<decimal> итого { get; set; }
    
        public virtual Клиенты Клиенты { get; set; }
        public virtual Товар Товар { get; set; }
    }
}
