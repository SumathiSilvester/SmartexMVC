using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartexMVC.Models;

namespace SmartexMVC.Controllers.BO
{
    public interface ITask
    {
        List<TaskDTO> GetTaskDetails();
        List<ProjectDTO> GetProjectDetails();
        TaskDTO GetTskByProjectID(Int64 TaskID,int ProjectID);
        int SaveTask(TaskDTO objtask);        
        int UpdateTask(TaskDTO objtask, Int64 TaskID);
        int SaveProject(ProjectDTO objproject);
        IEnumerable<ProjectDTO> GetProjectList();
    }
}
