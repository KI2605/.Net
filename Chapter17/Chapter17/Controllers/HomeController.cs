using Chapter17.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter17.Controllers
{
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;
        BukoContext db;
        public HomeController(BukoContext context)
        {

            db = context;
            if (!db.Services.Any())
            {

              //  Service dogs = new Service { Name = "Funny Dogs", Description = "Let's have some fun", ImageLink = "/asd.png" };
                Service ski = new Service { Name = "Ski School", Description = "Ваша самая большая мечта чтобы ребенок или Вы встали на лыжи? Ski School любит воплощать заветные мечты своих гостей.", ImageLink = "h:\root\\home\\ikolopatin-001\\www\\bukovel\\skichool.png" };
                Service s1 = new Service
                {
                    Name = "ПРОГУЛКИ НА СОБАЧЬИХ УПРЯЖКАХ",
                    Description = "Предлагается впервые на Украине! Незабываемая прогулка на нартах с ездовыми собаками породы 'сибирские хаски' лесными тропами на горнолыжном курорте 'Буковель'.Вы можете испытать себя в роли каюра(погонщика собак).Вы самостоятельно преодолеете определенное расстояние с контрольными точками на выбранном пути.Заказать эту услугу Вы сможете,возле проката,который находится возле нижней станции подъёмника №14.", 
                    ImageLink = " "
                };

                Service s2 = new Service
                {
                    Name = "КАФЕ «БУЛЬЧИНЕХА»",
                    Description = "В самом сердце 'Буковеля' на высоте 1150 м. есть место где собираются отдохнуть и восстановить силы отдыхающие и спортсмены после крутого путешествия на склонах Буковеля.Место уюта и тепла где царит домашняя атмосфера - это 'Бульчинеха'.Попробовать вкусные украинские блюда из душистым живым пивом,полакомиться свиными ребрышками,аппетитным стейком, настоящими кручениками с белыми грибами вы сможете именно здесь.Великолепный панорамный вид карпатских гор,и просторная накрытая терраса останутся в ваших сердцах навсегда.Ради ароматного глинтвейна и настоящего карпатского чая вам захочется еще раз съехать по заснеженным склонам к уютному заведению 'Бульчинеха' на верхней станции подъемников № 13 и № 3 горнолыжного курорта 'Буковель'.", 
                ImageLink = " "
                };

                Service s3 = new Service
                {
                    Name = "РОДЕЛЬБАН «SPEED FUN»",
                    Description = "В новом 2020 году в 'Буковеле' начал работу новый аттракцион - родельбан 'Speed Fun'.Это новая всепогодная санная трасса немецкой фирмы 'Виганд' впервые расположена на территории Украины. Начать захватывающий спуск на нашем аттракционе Вы сможете возле верхней станции подъёмника №2. ", 
                ImageLink = " "
                };

                Service s4 = new Service
                {
                    Name = "КАТОК",
                    Description = "Идеальное место для романтического свидания или возможность весело и оригинально провести время с друзьями. Не имеет значения сколько вам лет и насколько уверенно стоите на коньках и даже если вы первый раз обули коньки,   наши симпатичные «медведи», «пингвины» и «белочки» помогут вам не упасть и получить полное удовольствие от ледяного развлечения.  Обратите внимание! Администрация «Буковеля» и администраторы катка не несут ответственность за безопасность и вещи отдыхающих.  За безопасность детей на катке отвечают родители! Работает только в зимний период!", 
                ImageLink = " "
                };

                Service s5 = new Service
                {
                    Name = "ЭТНОПАРК «ГУЦУЛ ЛЕНД»",
                    Description = "Этнопарк 'Гуцул Ленд' – это увлекательные истории о жизни и быте горцев Украинских Карпат: гуцулов, бойков и лемков.", 
                ImageLink = " "
                };

                Service s6 = new Service
                {
                    Name = "РОУП-ДЖАМПИНГ",
                    Description = "Адреналиновая башня в 'Буковеле' - это самая высокая станция для роуп-джампинга в Украине. Высота башни 28 метров.Идеальна для любителей острых ощущений. Невероятные ощущения от свободного падения и взрыва эмоций гарантировано. Мы находимся на озере Молодости,  возле 'Voda club'.", 
                ImageLink = " "
                };


                db.Services.AddRange(s1,s2,s3,s4,s5,s6, ski);
                db.SaveChanges();
            }
            if (!db.Slopes.Any())
            {
                ///1
                Slope s1 = new Slope { Name = "1C", IsWorking = true, Level = "blue" };

                Slope s2 = new Slope { Name = "1A", IsWorking = true, Level = "red" };
                Slope s3 = new Slope { Name = "1B", IsWorking = true, Level = "black" };
                Slope s4 = new Slope { Name = "1D", IsWorking = true, Level = "red" };

                Slope s5 = new Slope { Name = "1E", IsWorking = true, Level = "blue" };

                ///2

                Slope s6 = new Slope { Name = "2A", IsWorking = true, Level = "red" };

                Slope s7 = new Slope { Name = "2B", IsWorking = true, Level = "red" };

                Slope s8 = new Slope { Name = "2E", IsWorking = true, Level = "red" };


                ///3
                Slope s9 = new Slope { Name = "3A", IsWorking = true, Level = "blue" };

                ///4

                ///5
                Slope s10 = new Slope { Name = "5G", IsWorking = true, Level = "red" };
                Slope s11 = new Slope { Name = "5H", IsWorking = true, Level = "black" };
                Slope s12 = new Slope { Name = "5F", IsWorking = true, Level = "black" };
                Slope s13 = new Slope { Name = "5E", IsWorking = true, Level = "black" };
                Slope s14 = new Slope { Name = "5D", IsWorking = true, Level = "red" };
                Slope s15 = new Slope { Name = "5B", IsWorking = true, Level = "blue" };
                ///6

                ///7
                Slope s16 = new Slope { Name = "7A", IsWorking = true, Level = "blue" };
                Slope s17 = new Slope { Name = "7B", IsWorking = true, Level = "blue" };
                ///8
                Slope s18 = new Slope { Name = "8A", IsWorking = true, Level = "red" };
                Slope s19 = new Slope { Name = "8B", IsWorking = true, Level = "red" };
                Slope s20 = new Slope { Name = "8C", IsWorking = true, Level = "red" };
                Slope s21 = new Slope { Name = "5D", IsWorking = true, Level = "blue" };


                ///11
                Slope s22 = new Slope { Name = "11B", IsWorking = true, Level = "black" };
                Slope s23 = new Slope { Name = "11C", IsWorking = true, Level = "black" };
                Slope s24 = new Slope { Name = "11D", IsWorking = true, Level = "red" };
                Slope s25 = new Slope { Name = "11E", IsWorking = true, Level = "red" };
                Slope s26 = new Slope { Name = "11F", IsWorking = true, Level = "blue" };

                //12

                Slope s27 = new Slope { Name = "12A", IsWorking = true, Level = "red" };
                Slope s28 = new Slope { Name = "12C", IsWorking = true, Level = "red" };
                Slope s29 = new Slope { Name = "12D", IsWorking = true, Level = "red" };

                //13
                Slope s30 = new Slope { Name = "13A", IsWorking = true, Level = "red" };
                Slope s31 = new Slope { Name = "13B", IsWorking = true, Level = "red" };
                Slope s32 = new Slope { Name = "13C", IsWorking = true, Level = "red" };
                Slope s33 = new Slope { Name = "13D", IsWorking = true, Level = "red" };
                Slope s34 = new Slope { Name = "13E", IsWorking = true, Level = "blue" };


                //14
               // Slope s35 = 
                ///15

                Slope s35 = new Slope { Name = "15A", IsWorking = true, Level = "red" };
                Slope s36 = new Slope { Name = "15B", IsWorking = true, Level = "red" };
                Slope s37 = new Slope { Name = "15C", IsWorking = true, Level = "red" };
                Slope s38 = new Slope { Name = "15E", IsWorking = true, Level = "blue" };
                //16
                Slope s39 = new Slope { Name = "16A", IsWorking = true, Level = "red" };
                Slope s40 = new Slope { Name = "16B", IsWorking = true, Level = "red" };
                Slope s41 = new Slope { Name = "16C", IsWorking = true, Level = "black" };
                Slope s42 = new Slope { Name = "16D", IsWorking = true, Level = "black" };
                Slope s43 = new Slope { Name = "16E", IsWorking = true, Level = "black" };



                //17
                Slope s44 = new Slope { Name = "17A", IsWorking = true, Level = "blue" };

                //22
                Slope s45 = new Slope { Name = "22A", IsWorking = true, Level = "black" };
                Slope s46 = new Slope { Name = "22B", IsWorking = true, Level = "black" };

                ///bukvi

                Slope s47 = new Slope { Name = "A", IsWorking = true, Level = "red" };
                Slope s48 = new Slope { Name = "B", IsWorking = true, Level = "blue" };
                Slope s49 = new Slope { Name = "D", IsWorking = true, Level = "blue" };
                Slope s50 = new Slope { Name = "E", IsWorking = true, Level = "red" };
                Slope s51 = new Slope { Name = "Z", IsWorking = true, Level = "blue" };
                Slope s52 = new Slope { Name = "K", IsWorking = true, Level = "blue" };
                Slope s53 = new Slope { Name = "J", IsWorking = true, Level = "blue" };

                db.Slopes.AddRange(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16, s17, s18, s19, s20, s21, s22, s23, s24, s25, s26, s27, s28, s29, s30, s31, s32, s33, s34, s35, s36, s37, s38, s39, s40, s41, s42, s43, s44, s45, s46, s47, s48, s49, s50, s51, s52, s53);
                db.Slopes.Add(new Slope { Name = "14A", IsWorking = true, Level = "blue" });
            }
            if (!db.Lifts.Any())
            {
                Lift s62 = new Lift { Name = "11", IsWorking = true, Mark = 1 };
                Lift s63 = new Lift { Name = "12", IsWorking = true, Mark = 1 };
                Lift s64 = new Lift { Name = "13", IsWorking = true, Mark = 1 };
                Lift s65 = new Lift { Name = "14", IsWorking = true, Mark = 1 };
                Lift s66 = new Lift { Name = "15", IsWorking = true, Mark = 1 };
                Lift s67 = new Lift { Name = "16", IsWorking = true, Mark = 1 };
                Lift s68 = new Lift { Name = "17", IsWorking = true, Mark = 1 };
                Lift s69 = new Lift { Name = "1r", IsWorking = true, Mark = 1 };
                Lift s70 = new Lift { Name = "2", IsWorking = true, Mark = 1 };
                Lift s71 = new Lift { Name = "22", IsWorking = true, Mark = 1 };
                Lift s72 = new Lift { Name = "2r", IsWorking = true, Mark = 1 };
                Lift s73 = new Lift { Name = "3", IsWorking = true, Mark = 1 };
                Lift s74 = new Lift { Name = "5", IsWorking = true, Mark = 1 };
                Lift s75 = new Lift { Name = "6", IsWorking = true, Mark = 1 };
                Lift s76 = new Lift { Name = "7", IsWorking = true, Mark = 1 };
                Lift s77 = new Lift { Name = "8", IsWorking = true, Mark = 1 };
                db.Lifts.AddRange(s62, s63, s64, s65, s66, s67, s68, s69, s70, s71, s72, s73, s74, s75, s76, s77);
                db.SaveChanges();
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        //[Route("Bukovel/GetServices")]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            return await db.Services.ToListAsync();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
       
        public async Task<IActionResult> Register(string name,string password)
        {
            
           // bool s;
            if (name == null)
            {
              
                return Content("No nickname");
            }
            // await db.Users.ToListAsync();
            
            foreach (var i in db.Users)
            {
                if (i.NickName == name)
                {
                    
                    return Content("Same user");

                }
            }
            User u1 = new User() { NickName = name, Password = password, IsAdmin = false };
            db.Users.Add(u1);
            await db.SaveChangesAsync();
            
            return Json("Hura");
        }
        [HttpGet]
        public IActionResult AddServiceReview()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddServiceReview(ServiceReview s)
        {
            float mark = 0f;
            float sum = 0f;
            float count = 0f;
            foreach (var j in db.Users.ToList())
            {
                if (j.NickName == s.User.NickName)
                {
                    foreach (var i in db.Services.ToList())
                    {
                        if (i.Name == s.Service.Name)
                        {
                            ServiceReview s1 = new ServiceReview { ServiceId = i.Id, Mark = s.Mark, Service = i, Review = "That's my opinion", User = j, UserId = j.Id };
                            //await db.ServiceReviews.ToListAsync();
                            //foreach (var j in db.ServiceReviews)
                            //{
                            //    j.ServiceId = s.ServiceId;
                            //    j.Mark = s.Mark;
                            //    //j.Service = from sc in db.Services
                            //    //            where sc.Id = 
                            //    //            select sc;
                            //    j.Service = i;
                            db.ServiceReviews.Add(s1);
                            db.SaveChanges();
                            foreach(var k in db.ServiceReviews)
                            {
                                if (k.ServiceId == s1.ServiceId)
                                {
                                    sum += k.Mark;
                                    count+=1;
                                }
                            }
                            mark = sum / count;
                            i.Mark = mark;
                            db.Services.Update(i);
                            db.SaveChanges();
                            return Content("good");
                            //}

                        }
                    }
                }
            }
            return Content("unable");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public JsonResult InfoService(string name)
        {
            foreach (var i in db.Services)
            {
                if (name == i.Name)
                {
                    Service s = new Service { Name = i.Name, Description = i.Description, ImageLink = i.ImageLink, Reviews = i.Reviews, Mark = i.Mark };
                    return Json(s);
                }
            }
            return Json("there is no service with this name in database");
        }
        
        [HttpGet]
        public IActionResult GetServiceReview(string name)
        {
            List<ServiceReviewClient> sr = new List<ServiceReviewClient>();
          //  IQueryable<User> users = db.Users;
            foreach (var i in db.Services)
            {
                if (i.Name == name)
                {
                    foreach(var j in db.ServiceReviews)
                    {
                        if (j.ServiceId == i.Id)
                        {
                            ServiceReviewClient sv = new ServiceReviewClient();
                            var u= db.Users.Find(j.UserId);
                            sv.UserNickName = u.NickName;
                            sv.ServiceName = j.Service.Name;
                            sv.Review = j.Review;
                            sv.Mark = j.Mark;
                            
                            sr.Add(sv);
                        }
                    }
                    return Json(sr);
                }
            }
            return Json("Hui");
        }

    }
    }
