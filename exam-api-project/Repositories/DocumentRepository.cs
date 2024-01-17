using ExamAPI.Context;
using ExamAPI.Models.ViewModels;
using ExamAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAPI.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly DatabaseContext context;
        private readonly ILogger<DocumentRepository> logger;

        public DocumentRepository(DatabaseContext context, ILogger<DocumentRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<List<DocumentViewModel>> Get(string dataareaid)
        {
            var documents = await (from doc in context.Document
                                   where doc.dataareaid == dataareaid
                                   orderby doc.createddatetime ascending
                                   select new DocumentViewModel
                                   {
                                       id = doc.id,
                                       dataareaid = doc.dataareaid,
                                       documentno = doc.documentno,
                                       description = doc.description,
                                       requesteddate = doc.requesteddate,
                                       status = doc.status
                                   }).ToListAsync();

            foreach (var document in documents)
            {
                var lastHistory = await context.DocumentHistory.Where(x => x.documentid == document.id).OrderByDescending(x => x.actiondatetime).FirstOrDefaultAsync();
                if (lastHistory != null)
                {
                    document.lastactionstatus = lastHistory.actionstatus;
                    document.lastactionby = lastHistory.actionby;
                    document.lastactiondatetime = lastHistory.actiondatetime;
                }
            }

            return documents;
        }
    }
}