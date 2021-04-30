using System;
using System.Collections.Generic;

namespace com.Github.Haseoo.BMMS.Data.Entities
{
    public class OrderList : Entity
    {
        public virtual string Name { get; set; }
        public virtual DateTime LastModification { get; set; }
        public virtual IList<OrderPosition> OrderPositions { get; set; }
    }
}
