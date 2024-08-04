using College.Models;
using College.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//************************************* [   buildin servicrs  ] **************
// add Services.AddSession
builder.Services.AddSession(c =>
{
    c.IdleTimeout = TimeSpan.FromMinutes(30);
});


//usermanger  singinmanager   IdentityUser    IdentityRole
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<collegecontext>();


// services addDbcontext 
// [1] step one       "  next step in collegecontext  model " 
builder.Services.AddDbContext<collegecontext>(options => options.
UseSqlServer(@"server = DESKTOP-DR5LS6Q ;Initial catalog = Dbcolloge ;Integrated security = true ; Encrypt = True; Trust Server Certificate = True"));




// **************** [     custom services   ]***************  
//  ==========================> [ step 4 ]   {step 1 ===> build repository , step 2 ==> build ITraineeRepository  ,  step 3 ===> in controller}
/* IOC Container ===> service provider
 * [1] register services  
 *     3 method
 * [1]  AddSingleton
 * [2]  AddScoped
 * [3]  AddTranisient
 */


builder.Services.AddScoped<ITraineeRepository,TraineeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IInstructoreRepository, InstructoreRepository>();
builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
builder.Services.AddScoped<ICourseResultRepository, CourseResultRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

// check cookie 
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
