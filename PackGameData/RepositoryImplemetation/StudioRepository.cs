using PackGameData.DataContext;
using PackGameData.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackGameData.RepositoryImplemetation
{
    public class StudioRepository:GenericRepository<Studio>,IStudioRepository
    {
    }
}
