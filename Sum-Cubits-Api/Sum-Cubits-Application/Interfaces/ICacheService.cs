namespace Sum_Cubits_Application.Application.Interfaces;

public interface ICacheService
{
    bool Exists(object key);
    TEntity? Get<TEntity>(object key);
    void Set(object key, object? value);
    void Remove(object key);
}