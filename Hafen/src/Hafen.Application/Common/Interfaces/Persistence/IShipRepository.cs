using Hafen.Domain.Entities;

namespace Hafen.Application.Common.Interfaces.Persistence;

public interface IShipRepository
{
    
    Ship? GetById(Guid id);

    Ship Add(Ship entity);

    Ship? Update(Ship entity);

    bool Delete(Guid id);

    List<Ship> List();

}