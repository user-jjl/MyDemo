using DemoFormApp.Data;
using DemoFormApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoFormApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            using (var context = new DemoContext())
            //useing ：非托管资源，需人工释放资源，防止泄露；相当于try-catch-finally{context.Dispose()}
            {   
                //插入数据
                //var department = new Department
                // {
                //    DepatmentNo = "D01",
                //    DepatmentName = "办公室"
                // };
                // context.Departments.Add(department);
                //context.SaveChanges();  //执行sql语句，操作数据库

                //多笔查询
                var result = context.Departments.ToList();  //tolist()查询
                var result_list = context.Departments.Where(x =>x.Id >1)
                    .OrderByDescending(x=>x.DepatmentNo)
                    .ToList();  //tolist()查询

                //单笔查询0笔 或1笔
                var result_single = context.Departments.Where(x => x.Id == 1)
                    .SingleOrDefault();

                //集合第一笔查询0笔 或1笔
                var result_first= context.Departments.Where(x => x.Id == 1)
                    .FirstOrDefault();

                //修改
                Department result_upd = context.Departments.Where(x => x.Id == 1)
                    .SingleOrDefault();
                if(result_upd != null)
                {   //通过context.  查询出来的数据，context会一直追踪，所以可以通过context.SaveChanges()修改
                    result_upd.DepatmentName="板材公司";
                    context.SaveChanges();
                }

                //删除
                Department result_del = context.Departments.Where(x => x.Id > 1)
                    .SingleOrDefault();
                if (result_del != null)
                {   //通过context.  查询出来的数据，context会一直追踪，所以可以通过context.SaveChanges()删除
                    context.Departments.Remove(result_del);
                    context.SaveChanges();
                }
            }

           
        }
    }
}
