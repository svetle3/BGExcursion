namespace BGExcursion.DAL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Tbl_Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Product()
        {
            this.Tbl_Cart = new HashSet<Tbl_Cart>();
        }
    
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Необходимо e име с дължина от 3 до 80 символа")]
        [StringLength(80,MinimumLength =3, ErrorMessage = "Невалидно име")]
        public string ProductName { get; set; }        
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> SubcategoryId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<System.DateTime> Description { get; set; }
        
        public string ProductImage { get; set; }
        public Nullable<bool> IsFeatured { get; set; }
        [Range(0, 300)]
        public Nullable<int> Quantity { get; set; }
        [Range(10,500)]
        public Nullable<int> Price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Cart> Tbl_Cart { get; set; }
        public virtual Tbl_Category Tbl_Category { get; set; }
        public virtual Tbl_Subcategory Tbl_Subcategory { get; set; }
    }
}
