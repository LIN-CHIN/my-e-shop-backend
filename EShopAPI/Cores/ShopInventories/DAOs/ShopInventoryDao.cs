using EShopAPI.Cores.ShopInventories.DTOs;

namespace EShopAPI.Cores.ShopInventories.DAOs
{
    /// <summary>
    /// /// <summary>
    /// 商店庫存 DAO 
    /// </summary>
    /// </summary>
    public class ShopInventoryDao : IShopInventoryDao
    {
        ///<inheritdoc/>
        public IQueryable<ShopInventory> Get(QueryShopInventoryDto queryDto)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public async Task<ShopInventory?> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public async Task<ShopInventory?> GetByNumberAsync(string number)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public async Task<ShopInventory> InsertAsync(ShopInventory shopInventory)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(ShopInventory shopInventory)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public async Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
