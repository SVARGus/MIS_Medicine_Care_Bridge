namespace MedicineCareBridge.Shared.DTO.Shared
{
    /// <summary>
    /// Представляет результат постраничного запроса.
    /// Используется для передачи списка элементов вместе с метаданными пагинации.
    /// </summary>
    /// <typeparam name="T">Тип элементов в результирующем списке.</typeparam>
    public class PaginatedResult<T>
    {
        /// <summary>
        /// Создаёт новый экземпляр <see cref="PaginatedResult{T}"/>.
        /// </summary>
        /// <param name="items">Список элементов текущей страницы.</param>
        /// <param name="totalCount">Общее число элементов во всем наборе.</param>
        /// <param name="pageNumber">Номер текущей страницы (начиная с 1).</param>
        /// <param name="pageSize">Размер страницы.</param>
        public PaginatedResult(IEnumerable<T> items, int totalCount, int pageNumber, int pageSize)
        {
            Items = items ?? throw new ArgumentNullException(nameof(items));
            TotalCount = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        /// <summary>
        /// Элементы текущей страницы.
        /// </summary>
        public IEnumerable<T> Items { get; }

        /// <summary>
        /// Общее число элементов во всем наборе (до разбивки на страницы).
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        /// Номер текущей страницы (начиная с 1).
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// Размер страницы (количество элементов на одну страницу).
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// Общее число страниц, вычисляемое как Ceiling(TotalCount / (double)PageSize).
        /// </summary>
        public int TotalPages
            => PageSize > 0
                ? (int)Math.Ceiling(TotalCount / (double)PageSize)
                : 0;
    }
}
