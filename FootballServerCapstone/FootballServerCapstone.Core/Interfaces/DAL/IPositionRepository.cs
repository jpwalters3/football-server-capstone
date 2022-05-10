using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballServerCapstone.Core.Entities;

namespace FootballServerCapstone.Core.Interfaces.DAL
{
    public interface IPositionRepository
    {
        public Response<Position> GetById(int positionId);
    }
}
