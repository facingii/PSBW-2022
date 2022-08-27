using System;
using System.Collections.Generic;
using System.Linq;
using EntiityFramworkFundamentals.Models;

namespace EFFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            // obtenemos el contexto que nos permite realizar operaciones CRUD sobre la conexión a la BD 
            employeesContext context = new employeesContext();

            // Recorre la tabla departamentos interando por cada uno de los elementos
            // SELECT * FROM Departments;
            //
            //foreach (var d in context.Departments)
            //{
            //    Console.WriteLine(d.DeptNo);
            //}

            // La función find realiza una búsqueda utilizando el campo llave de la tabla, su representación en SQL es
            // SELECT * FROM Departments WHERE dept_no = 'd005';
            //
            //context.Departments.Find (new Object [] { "d005" });
            //var department = context.Departments.Find (new object[] { "d005" });
            //Console.WriteLine (department?.DeptName);

            //var task = context.Departments.FindAsync (new object[] { "d005" });
            //Console.WriteLine("OP. adicionales");

            //Console.WriteLine("Mas OP. adicionales");

            //Console.WriteLine ("Departamento encontrado {0}", task.Result.DeptName);

            //
            // INSERT INTO employees VALUES (10, '21/10/2018', 'AAA', 'BBB', 'M', '21/10/2018');
            //
            //context.Employees.Add(new Employee ()
            //{
            //    EmpNo = 10,
            //    BirthDate = DateOnly.FromDateTime (DateTime.Now),
            //    FirstName = "AAA",
            //    LastName = "BBB",
            //    Gender = "M",
            //    HireDate = DateOnly.FromDateTime (DateTime.Now)
            //});

            //
            // INSERT INTO departments VALUES ('9999', 'SISTEMA WEB');
            //
            //context.Departments.Add(new Department ()
            //{
            //    DeptNo = "9999",
            //    DeptName = "SISTEMA WEB"
            //});

            //context.SaveChanges ();

            //
            // DELETE FROM employees WHERE no_emp = 10;
            //
            //var emp = context.Employees.Find (new object [] { 10 });
            //context.Employees.Remove (emp);
            //context.SaveChanges ();


            // esta forma de consulta utiliza la función extendida Where, utilizando la función lambda como
            // forma de filtrado
            //var employee = context.Employees.Where<Employee>(e => e.FirstName == "AAA").FirstOrDefault<Employee>();
            //employee.LastName = "CCC";
            //context.SaveChanges();

            // en esta forma se utiliza la forma de selección que utiliza una estructura tipo sql para definir
            // los parámetros de la consulta
            //var dept = (from d in context.Departments
            //                    where d.DeptNo == "9999"
            //                    select d).FirstOrDefault<Department>();

            //dept.DeptName = "PROGRAMACION DE SISTEMAS BASADOS EN WEB";
            //context.SaveChanges ();

            // la función First devuelve el primer registro de la colección consultada
            //var e1 = context.Employees.First<Employee>();
            //Console.WriteLine ("{0} {1}", e1.FirstName, e1.LastName);


            //var depto = context.Departments.Where(d => d.DeptName.Equals("Development")).FirstOrDefault();
            //context.Employees.Add (
            //    new Employee ()
            //    {
            //        EmpNo = 10,
            //        FirstName = "AAA",
            //        LastName = "BBB",
            //        BirthDate = new DateOnly (1980, 12, 12),
            //        Gender = "M",
            //        HireDate = DateOnly.FromDateTime (DateTime.Now),

            //        Titles = new List<Title>() {
            //            new Title () {
            //                 EmpNo = 10,
            //                 Title1 = "Senior Developer",
            //                 FromDate = DateOnly.FromDateTime (DateTime.Now),
            //                 ToDate = DateOnly.FromDateTime (DateTime.Now.AddDays (365))
            //            }
            //        },

            //        Salaries = new List<Salary>() {
            //            new Salary () {
            //                EmpNo = 10,
            //                FromDate = DateOnly.FromDateTime (DateTime.Now),
            //                Salary1  = 1000,
            //                ToDate = DateOnly.FromDateTime (DateTime.Now.AddDays (365))
            //            }
            //        },

            //        DeptEmps = new List<DeptEmp>() {
            //            new DeptEmp () {
            //                DeptNo = depto.DeptNo,
            //                FromDate = DateOnly.FromDateTime (DateTime.Now),
            //                ToDate = DateOnly.FromDateTime (DateTime.Now.AddDays (365)),
            //                EmpNo = 10
            //            }
            //        },

            //        DeptManagers = new List<DeptManager>() {
            //            new DeptManager () {
            //                DeptNo = depto.DeptNo,
            //                EmpNo = 10,
            //                FromDate = DateOnly.FromDateTime (DateTime.Now),
            //                ToDate = DateOnly.FromDateTime (DateTime.Now.AddDays (365))
            //            }
            //        }
            //    }); 


            //guardamos los cambios realizados en las colecciones ligadas al contexto
            //context.SaveChanges ();

            //var result = context.Employees.Join (context.Titles, e => e.EmpNo, t => t.EmpNo, (t1, t2) => t1);

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //var result1 = from e in context.Employees
            //              join
            //            t in context.Titles on e.EmpNo equals t.EmpNo
            //              select new
            //              {
            //                  nombreCompleto = e.FirstName + " " + e.LastName,
            //                  titulo = t.Title1,
            //                  contratado = t.FromDate
            //              };

            //foreach (var item in result1)
            //{
            //    Console.WriteLine (item.nombreCompleto);
            //}

            // en este ejemplo se realiza la consulta de unión de 3 tablas, 2 de ellas están vinculadas
            // entre sí, pero la tercera no
            // 
            // SELECT employees.first_name FROM employees INNER JOIN
            // (SELECT dept_manager.emp_no FROM dept_manager INNER JOIN departments ON
            // dept_manager.dept_no = departments.dept_no WHERE departments.dept_no = 'd005') deptos ON employees.emp_no = deptos.emp_no
            //
            //var result2 = from e in context.Employees
            //              join x in (from dm in context.DeptManagers
            //                         join d in context.Departments on dm.DeptNo equals d.DeptNo
            //                         where d.DeptNo == "d005"
            //                         select dm) on e.EmpNo equals x.EmpNo
            //              select new
            //              {
            //                  nombreCompleto = e.FirstName + " " + e.LastName
            //              };

            //foreach (var item in result2)
            //{
            //    Console.WriteLine(item);
            //}

            // otra posibilidad es tener realizar la consulta con 3 tablas relacionadas
            //var result3 = from e in context.Employees
            //              join dm in context.DeptManagers on e.EmpNo equals dm.EmpNo
            //              join t in context.Titles on e.EmpNo equals t.EmpNo
            //              select new
            //              {
            //                  HiredOn = e.HireDate,
            //                  FullName = e.FirstName + " " + e.LastName,
            //                  Depto = dm.DeptNo,
            //                  t.Title1
            //              };

            //foreach (var item in result3)
            //{
            //    Console.WriteLine("{0} fue contratado en {1} bajo el título {2} para el departamento {3}",
            //        item.FullName, item.HiredOn, item.Title, item.Depto);
            //}

            var transaction = context.Database.BeginTransaction();

            try
            {
                Department d = new Department ();
                d.DeptNo = "5555";
                d.DeptName = "Math";

                context.Departments.Add(d);

                context.Employees.Add(
                    new Employee
                    {
                        EmpNo = 40,
                        FirstName = "KAR",
                        LastName = "TRIN",
                        Gender = "F",
                        BirthDate = DateOnly.FromDateTime (DateTime.Now),
                        HireDate = DateOnly.FromDateTime (DateTime.Now)
                    }
                );

                context.DeptEmps.Add(
                    new DeptEmp
                    {
                        DeptNo = "5555",
                        EmpNo = 30,
                        FromDate = DateOnly.FromDateTime (DateTime.Now),
                        ToDate = DateOnly.FromDateTime (DateTime.Now)
                    }
                );


                context.SaveChanges();
                transaction.Commit();
                Console.WriteLine("Información almacenada!");
            }
            catch (Exception ex)
            {
                Console.WriteLine ("Error ocurrido.");
                Console.WriteLine (ex?.InnerException?.Message);
            }


            transaction.Dispose();

        }
    }
}