using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4.EF.Business.Domain;
using TP4.EF.Business.Logic;

namespace TP4.EF.UI.Consola
{
    class Program
    {
        static string MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("POC - Entity Framework");
            Console.WriteLine("======================");
            Console.WriteLine("INGRESE EL NUMERO DE LA OPCION DESEADA:");
            Console.WriteLine("1 - Mostrar Datos de Entidad");
            Console.WriteLine("2 - Insertar Entidad");
            Console.WriteLine("3 - Eliminar Entidad");
            Console.WriteLine("4 - Actualizar Entidad");
            Console.WriteLine("0 - Salir");
            Console.Write(":");
            return Console.ReadLine();
        }

        static string MostrarDatosEntidad()
        {
            Console.Clear();
            Console.WriteLine("Mostrar Datos de Entidad");
            Console.WriteLine("========================");
            Console.WriteLine("INGRESE EL NUMERO DEL TIPO DE ENTIDAD DESEADA:");
            Console.WriteLine("1 - Categorias");
            Console.WriteLine("2 - Empleados");
            Console.WriteLine("0 - Salir");
            Console.Write(":");
            return Console.ReadLine();
        }

        static string InsertarEntidad()
        {
            Console.Clear();
            Console.WriteLine("Insertar Entidad");
            Console.WriteLine("================");
            Console.WriteLine("INGRESE EL NUMERO DEL TIPO DE ENTIDAD DESEADA:");
            Console.WriteLine("1 - Categorias");
            Console.WriteLine("0 - Salir");
            Console.Write(":");
            return Console.ReadLine();
        }

        static string EliminarEntidad()
        {
            Console.Clear();
            Console.WriteLine("Eliminar Entidad");
            Console.WriteLine("================");
            Console.WriteLine("INGRESE EL NUMERO DEL TIPO DE ENTIDAD DESEADA:");
            Console.WriteLine("1 - Categorias");
            Console.WriteLine("0 - Salir");
            Console.Write(":");
            return Console.ReadLine();
        }

        static string ActualizarEntidad()
        {
            Console.Clear();
            Console.WriteLine("Actualizar Entidad");
            Console.WriteLine("==================");
            Console.WriteLine("INGRESE EL NUMERO DEL TIPO DE ENTIDAD DESEADA:");
            Console.WriteLine("1 - Categorias");
            Console.WriteLine("0 - Salir");
            Console.Write(":");
            return Console.ReadLine();
        }
        
        #region Categories

        #region Insertar
        static string IngresarDescipcionCategoria()
        {
            Console.WriteLine("INGRESE LA DESCRIPCION DE LA CATEGORIA:");
            Console.Write(":");
            return Console.ReadLine();
        }
        static string IngresarNombreCategoria()
        {
            Console.WriteLine("INGRESE EL NOMBRE DE LA CATEGORIA:");
            Console.Write(":");
            return Console.ReadLine();
        }
        #endregion

        #region Eliminar
        static string IngresarIDCategoriaEliminar()
        {
            Console.WriteLine("INGRESE EL ID DE LA CATEGORIA A ELIMINAR:");
            Console.Write(":");
            return Console.ReadLine();
        }
        #endregion

        #region Actualizar
        static string IngresarIDCategoriaActualizar()
        {
            Console.WriteLine("INGRESE EL ID DE LA CATEGORIA A ACTUALIZAR:");
            Console.Write(":");
            return Console.ReadLine();
        }
        static string IngresarNuevoNombreCategoria()
        {
            Console.WriteLine("INGRESE NUEVO NOMBRE DE LA CATEGORIA:");
            Console.Write(":");
            return Console.ReadLine();
        }
        #endregion

        #endregion

        static void Main(string[] args)
        {
            while (!int.TryParse(MenuPrincipal(), out int opcionMenuPrincipal) || opcionMenuPrincipal != 0)
            {
                switch (opcionMenuPrincipal)
                {
                    case 1:
                        while (!int.TryParse(MostrarDatosEntidad(), out int opcionMostrarDatosEntidad) || opcionMostrarDatosEntidad != 0)
                        {
                            switch (opcionMostrarDatosEntidad)
                            {
                                case 1:
                                    CategoriesLogic categoriesLogic = new CategoriesLogic();
                                    try
                                    {
                                        var table = new ConsoleTable("ID", "Name", "Description");
                                        foreach (Categories category in categoriesLogic.GetAll())
                                        {                                            
                                            table.AddRow(category.CategoryID, category.CategoryName, category.Description);
                                        }
                                        table.Write();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    finally
                                    {
                                        Console.WriteLine("Presione una tecla para continuar...");
                                        Console.ReadLine();
                                    }
                                    break;
                                case 2:
                                    EmployeesLogic employeesLogic = new EmployeesLogic();
                                    try
                                    {
                                        var table = new ConsoleTable("ID", "Title", "First Name", "Last Name", "City", "Country");
                                        foreach (Employees employee in employeesLogic.GetAll())
                                        {
                                            table.AddRow(employee.EmployeeID, employee.Title, employee.FirstName, employee.LastName, employee.City, employee.Country);
                                        }
                                        table.Write();
                                    }
                                    catch(Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    finally
                                    {
                                        Console.WriteLine("Presione una tecla para continuar...");
                                        Console.ReadLine();
                                    }
                                    break;
                                case 0:
                                    break;
                            }
                        }
                        break;
                    case 2:
                        while (!int.TryParse(InsertarEntidad(), out int opcionInsertarEntidad) || opcionInsertarEntidad != 0)
                        {
                            switch (opcionInsertarEntidad)
                            {
                                case 1:
                                    Categories newCategory = new Categories();
                                    newCategory.CategoryName = IngresarNombreCategoria();
                                    newCategory.Description = IngresarDescipcionCategoria();

                                    CategoriesLogic categoriesLogic = new CategoriesLogic();
                                    try
                                    {
                                        categoriesLogic.Add(newCategory);
                                        var table = new ConsoleTable("ID", "Name", "Description");
                                        foreach (Categories category in categoriesLogic.GetAll())
                                        {
                                            table.AddRow(category.CategoryID, category.CategoryName, category.Description);
                                        }
                                        table.Write();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    finally
                                    {
                                        Console.WriteLine("Presione una tecla para continuar...");
                                        Console.ReadLine();
                                    }
                                    break;
                                case 0:
                                    break;
                            }
                        }
                        break;
                    case 3:
                        while (!int.TryParse(EliminarEntidad(), out int opcionEliminarEntidad) || opcionEliminarEntidad != 0)
                        {
                            switch (opcionEliminarEntidad)
                            {
                                case 1:
                                    CategoriesLogic categoriesLogic = new CategoriesLogic();
                                    try
                                    {
                                        var table = new ConsoleTable("ID", "Name", "Description");
                                        foreach (Categories category in categoriesLogic.GetAll())
                                        {
                                            table.AddRow(category.CategoryID, category.CategoryName, category.Description);
                                        }
                                        table.Write();

                                        int idEliminarCategoria = int.Parse(IngresarIDCategoriaEliminar());

                                        categoriesLogic.Delete(idEliminarCategoria);

                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    finally
                                    {
                                        Console.WriteLine("Presione una tecla para continuar...");
                                        Console.ReadLine();
                                    }
                                    break;
                                case 0:
                                    break;
                            }
                        }
                        break;
                    case 4:
                        while (!int.TryParse(ActualizarEntidad(), out int opcionActualizarEntidad) || opcionActualizarEntidad != 0)
                        {
                            switch (opcionActualizarEntidad)
                            {
                                case 1:
                                    CategoriesLogic categoriesLogic = new CategoriesLogic();
                                    try
                                    {
                                        var table = new ConsoleTable("ID", "Name", "Description");
                                        foreach (Categories category in categoriesLogic.GetAll())
                                        {
                                            table.AddRow(category.CategoryID, category.CategoryName, category.Description);
                                        }
                                        table.Write();

                                        int idUpdateCategoria = int.Parse(IngresarIDCategoriaActualizar());
                                        
                                        var updateCategoria = categoriesLogic.GetByID(idUpdateCategoria);

                                        updateCategoria.CategoryName = IngresarNuevoNombreCategoria();

                                        categoriesLogic.Update(updateCategoria);

                                        foreach (Categories category in categoriesLogic.GetAll())
                                        {
                                            table.AddRow(category.CategoryID, category.CategoryName, category.Description);
                                        }
                                        table.Write();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    finally
                                    {
                                        Console.WriteLine("Presione una tecla para continuar...");
                                        Console.ReadLine();
                                    }
                                    break;
                                case 0:
                                    break;
                            }
                        }
                        break;
                    case 0:
                        break;
                }
            }
        }
    }
}
