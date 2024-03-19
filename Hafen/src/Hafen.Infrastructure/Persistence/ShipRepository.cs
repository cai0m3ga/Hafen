using Hafen.Application.Common.Interfaces.Persistence;
using Hafen.Domain.Entities;

namespace Hafen.Infrastructure.Persistence;

public class ShipRepository : IShipRepository
{

    private static readonly List<Ship> _ships = new();

    public Ship Add(Ship entity)
    {

        _ships.Add(entity);
        return entity;

    }

    public bool Delete(Guid id)
    {

        var dbEntentity = GetById(id);

        if (dbEntentity is null)
            return false;

        _ships.Remove(dbEntentity);

        return true;

    }

    public Ship? GetById(Guid id)
    {

        return _ships.FirstOrDefault(e => e.Id == id);

    }

    public List<Ship> List()
    {

        return _ships;

    }

    public Ship? Update(Ship entity)
    {

        var dbEntentity = GetById(entity.Id);

        if (dbEntentity is null)
            return null;

        dbEntentity.Update(entity.Name, entity.Length, entity.Width, entity.Code);

        return dbEntentity;

    }

}