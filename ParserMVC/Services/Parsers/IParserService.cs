using parser.Models.Entities;

namespace parser.Services.Parsers
{
    /// <summary>
    /// Обновляет цены товаров по их ссылкам в магазинах и записывает актуальные цены в базу данных
    /// </summary>

    public interface IParserService
    {
        /// <summary>
        /// Возвращает список продуктов относящихся к конкретному магазину
        /// </summary>
        /// <returns>Список продуктов относящихся к конкретному магазину</returns>
        /// 
        public Task<List<Product>> GetProductAsync();

        /// <summary>
        /// Возвращает актуальную цену продукта, получая его из url
        /// </summary>
        /// <param name="url">Ссылка на товар</param>
        /// <returns>Актуальная цена продукта</returns>
        /// 
        public Task<uint> GetPriceAsync(string url);

        /// <summary>
        /// Обновляет цены товаров в базе данных до актуальных
        /// </summary>
        /// <returns>Результат обновления цен</returns>

        public Task<bool> UpdatePrices();
    }
}
