using Projek_UTSAren.Data;
using Projek_UTSAren.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Projek_UTSAren.Services;
using Projek_UTSAren.Helper;

namespace Projek_UTSAren.Controllers
{
    public class AkunController : Controller
    {

        private readonly AppDbContext _context;
        private readonly EmailService _email;
        private static int _OTP;

        public AkunController(AppDbContext context, EmailService e)
        {
            _context = context;
            _email = e;
        }

        public IActionResult Daftar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Daftar(User datanya, int otp)
        {
            if (otp == _OTP)
            {
                Roles cariRoles = _context.Tb_Roles.FirstOrDefault(x => x.Id == "2");

                datanya.Roles = cariRoles;

                _context.Tb_User.Add(datanya);
                _context.SaveChanges();

                return RedirectToAction("Masuk");
            }
            return View(datanya);
        }


        public IActionResult Masuk()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Masuk(User datanya)
        {

            var cariusername = _context.Tb_User.Where(
                                            bebas =>
                                            bebas.Username == datanya.Username
                                            ).FirstOrDefault();

            if (cariusername != null)
            {
                var cekpassword = _context.Tb_User.Where(
                                            bebas =>
                                            bebas.Username == datanya.Username
                                            &&
                                            bebas.Password == datanya.Password
                                            )
                                    .Include(bebas2 => bebas2.Roles)
                                    .FirstOrDefault();

                if (cekpassword != null)
                {
                  
                    var daftar = new List<Claim>
                    {
                        new Claim("Nama_Lengkap", cariusername.Nama_Lengkap),
                        new Claim("Role", cariusername.Roles.Id)
                    };

                    await HttpContext.SignInAsync(
                        new ClaimsPrincipal(
                            new ClaimsIdentity(daftar, "Cookie", "Nama_Lengkap", "Role")
                            )
                        );

                    if (cariusername.Roles.Id == "1")
                    {
                        return Redirect("/Admin/Home");
                    }
                    else if(cariusername.Roles.Id == "2")
                    {
                        return Redirect("/User/Home");
                    }

                    return RedirectToAction(controllerName: "Alumni", actionName: "Index");
                }

                ViewBag.pesan = "Password Anda Salah";

                return View(datanya);
            }

            ViewBag.pesan = "Username Anda Tidak Ada";

            return View(datanya);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }


        [HttpPost]
        public object KirimEmailOTP(string emailTujuan)
        {
            var cariEmail = _context.Tb_User.FirstOrDefault(x => x.Email == emailTujuan);

            if (cariEmail != null) return new { result = false, message = "Email " + emailTujuan + " sudah terdaftar" };

            BanyakBantuan _bantu = new();
            _OTP = _bantu.BuatOTP();
            string subjeknya = "Konfirmasi email untuk daftar akun";
            string isiEmailnya =
                "<h1>Berikut OTP anda <i style='color: red;'>"
                + _OTP.ToString()
                + "</i></h1>"
                + "<a href='mailto:dotnetlanjutan@gmail.com?subject=Bantuan&body=Halo'>Bantuan</a>";

            bool cek = _email.KirimEmail(emailTujuan, subjeknya, isiEmailnya); 

            if (cek) return new { result = true, message = "Email berhasil dikirimkan ke " + emailTujuan };

            return new { result = false, message = "Email " + emailTujuan + " tidak ditemukan" };
        }

    }
}