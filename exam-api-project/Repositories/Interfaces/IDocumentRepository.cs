using ExamAPI.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamAPI.Repositories.Interfaces
{
    public interface IDocumentRepository
    {
        Task<List<DocumentViewModel>> Get(string dataareaid);
    }
}