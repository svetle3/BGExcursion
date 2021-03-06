//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BGExcursion.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Tbl_ShippingDetails
    {
        public int ShippingDetailId { get; set; }
        public Nullable<int> MemberId { get; set; }
        [Required(ErrorMessage = "���������� e ����� � ������� �� 5 �� 80 �������")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "��������� �����")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "��������� e ���� � ������� �� 5 �� 80 �������")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "��������� ����")]
        public string City { get; set; }
        [Required(ErrorMessage = "���������� � ������ � ������� �� 5 �� 80 �������")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "��������� ������")]
        public string State { get; set; }
        [Required(ErrorMessage = "���������� e ������� � ������� �� 5 �� 80 �������")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "��������� �������")]
        public string Country { get; set; }
        [Range (1000,5000)]
        public string ZipCode { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<decimal> AmountPaid { get; set; }
        public string PaymentType { get; set; }
    
        public virtual Tbl_Members Tbl_Members { get; set; }
        public virtual Tbl_Members Tbl_Members1 { get; set; }
    }
}
