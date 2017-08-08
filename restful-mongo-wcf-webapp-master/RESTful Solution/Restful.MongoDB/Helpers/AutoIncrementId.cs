using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful.MongoDB.Helpers
{
    public class AutoIncrementId
    {
        public async Task<T> GenerateId<T>(IMongoCollection<T> collection)
        {
            var lastRecordedData = await Task.Run(() => collection.Find(t => true)
                                        .Sort(new SortDefinitionBuilder<T>().Descending("$natural"))
                                        .FirstOrDefaultAsync()).ConfigureAwait(false);
            return lastRecordedData;
        }
    }
}
