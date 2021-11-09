﻿using EFLazyLoadingRepository.Dao;
using Microsoft.EntityFrameworkCore;

namespace EFLazyLoadingRepository;

public class EagerLoadingRepository : IDbContextRepository
{
    private readonly PocDbContext _db;

    public EagerLoadingRepository(string connectionString) => _db = new(new DbContextOptionsBuilder<PocDbContext>().UseSqlite(connectionString).Options);

    public IEnumerable<Blog> GetBlogsRange(int index, int number) => _db.Blogs.Select(b => b).OrderBy(b => b.Id).Skip(index).Take(number).Include(b => b.Posts).AsEnumerable();

}