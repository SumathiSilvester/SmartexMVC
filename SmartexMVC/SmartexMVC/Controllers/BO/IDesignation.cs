using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartexMVC.Models;

namespace SmartexMVC.Controllers.BO
{
    public interface IDesignation
    {
        List<Designation> GetDesignation();
        Designation GetDesigantionByID(int DesigID);
        int SaveDesignation(Designation objdesig);
        int DeleteDesignation(int DesigID);
        int UpdateDesignation(Designation objdesig, int DesigID);

    }
}
