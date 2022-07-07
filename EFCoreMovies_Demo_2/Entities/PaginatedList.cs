﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies_Demo_2.Entities;

public class PaginatedList<T> : List<T>
{
    public int PageIndex { get; private set; }
    public int TotalPages { get; set; }
    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalPages = Convert.ToInt32(Math.Ceiling(count / Convert.ToDouble(pageSize)));
        AddRange(items);
    }

    public bool PreviousPage
    {
        get
        {
            return (PageIndex > 1);
        }
    }

    public bool NextPage
    {
        get
        {
            return (PageIndex < TotalPages);

        }

        set{}
    }

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PaginatedList<T>(items, count, pageIndex, pageSize);
    }
}