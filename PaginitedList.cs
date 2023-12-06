using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FaulknerCountyMuseumGallery
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        private static Random rng;

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
            rng = new Random();
        }
        public PaginatedList(List<T> items, int pageIndex, int totalPages, Random rand)
        {
            PageIndex = pageIndex;
            TotalPages = totalPages;
            this.AddRange(items);
            rng = rand;
        }
        public PaginatedList<T> shuffle() {
            return new PaginatedList<T>(this.OrderBy(a => rng.Next()).ToList(), PageIndex, TotalPages, rng);
        }
        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;
        public int getPageIndex() {return PageIndex;}
        public int getTotalPages() {return TotalPages;}

        public static async Task<PaginatedList<T>> CreateAsync(
            IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip(
                (pageIndex - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}