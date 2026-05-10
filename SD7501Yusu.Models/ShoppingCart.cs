using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YusuWeb.Models;

namespace SD7501Yusu.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }
        [Range(1,1000,ErrorMessage ="Please enter a value between 1 and 1000")]
        public int Count {  get; set; }
       public string ApplicationUserId {  get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public double Price { get; set; }//你有某个属性只在代码中使用，不希望数据库表中生成对应的列。例如：计算属性、临时数据、密码确认字段等。
    }

}
