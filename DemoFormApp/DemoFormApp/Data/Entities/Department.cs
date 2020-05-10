using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFormApp.Data.Entities
{
    class Department
    {
        public int Id { get; set; }
        
        [MaxLength(20)]  //最大长度20
        [Required]          //必填
        public string DepatmentNo{ get; set; }

        [MaxLength(100),Required]  //特性：最大长度100  必填
        public string DepatmentName { get; set; }

        [MaxLength(500)]  //特性：最大长度500
        public string Remark { get; set; }
    }
}
