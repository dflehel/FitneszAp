using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppPro.Logic
{
    public class DatabaseController
    {
        private FitneszDBContext database;

        public DatabaseController()
        {
            this.database = new FitneszDBContext();
        }
        public List<Tipu> GetTipus()
        {
            return this.database.Tipus.ToList() ?? new List<Tipu>();
        }

        public List<Ertek> GetErteks()
        {
            return this.database.Erteks.ToList() ?? new List<Ertek>();
        }

        public void AddErtek(System.DateTime mikortol,System.DateTime meddig,string ar, Tipu t)
        {
            this.database.Erteks.Add(new Ertek { Mikortol = mikortol, Meddig = meddig, Ar = Convert.ToDecimal(ar), Tipus = t.Id, Tipu = t });
            this.database.SaveChanges();
        }


        public void AddTipus(string leiras)
        {
            this.database.Tipus.Add(new Tipu { Leiras = leiras });
            this.database.SaveChanges();
        }

        public void AddUser(string firstname, string lastname, string kod)
        {
            User u = new User();
            u.First_Name = firstname;
            u.Last_Name = lastname;
            u.Kod = kod;
            this.database.Users.Add(u);
            this.database.SaveChanges();
        }
        public void AddUser(string firstname, string lastname, string kod, byte[] pic)
        {
            User u = new User();
            u.First_Name = firstname;
            u.Last_Name = lastname;
            u.Kod = kod;
            u.Picture = pic;
            this.database.Users.Add(u);
            this.database.SaveChanges();
        }
        public List<User> getUsers()
        {
            return this.database.Users.ToList();
        }

        public void addBerlet(Berlet b)
        {
            this.database.Berlets.Add(b);
            this.database.SaveChanges();
        }

        public void addVasarlas(Vasarolt v)
        {
            this.database.Vasarolts.Add(v);
            this.database.SaveChanges();
        }

        public Ertek getErtekByTipus(Tipu t)
        {
            return this.database.Erteks.Where(x => x.Tipus == t.Id).ToList().Last() ?? null;
        }
  
        public void deleteUser(User u)
        {
            this.database.Users.Remove(u);
            this.database.SaveChanges();
        }
        public List<Berlet> getBerletek()
        {
            return this.database.Berlets.ToList();
        }

        public void AddAbonament(int idotartam, int belepesekszama, int kezdo, int vegzo, byte[] napok)
        {
            Berlet a = new Berlet();
            a.Id = this.database.Berlets.Last().Id + 1;
            a.Idotartam = idotartam;
            a.Kezdeti_ora = kezdo;
            a.Napok = napok;
            a.Veg_ora = vegzo;
            a.Belepesek_szama = belepesekszama;
            a.Aktiv = true;
            this.database.Berlets.Add(a);
            this.database.SaveChanges();
        }

        /*public void AddVasarlas(User u, Berlet a,Tipu t)
        {
            Vasarolt v = new Vasarolt();
            v.Id = this.database.Vasarolts.Last().Id + 1;
            v.User = u.Id;
            v.Berlet = a.Id;
            v.Ertek = this.database.Erteks.Where(e => e.Tipus == t.Id).Last().Id;
            this.database.Vasarolts.Add(v);
            this.database.SaveChanges();
        }*/

        public void AddBelepes(User u, Berlet a)
        {
            Belepe b = new Belepe();
            b.Ki = u.Id;
            b.Id = this.database.Belepes.Last().Id + 1;
            b.Melyik_Berlet = a.Id;
            b.Mikor_jott = System.DateTime.Now;
            this.database.Belepes.Add(b);
            this.database.SaveChanges();
        }

        public void kilepes(User u, Berlet a)
        {
            Belepe b = this.database.Belepes.Where(be => be.Ki == u.Id && be.Melyik_Berlet == a.Id).Last();
            b.Mikor_ment = System.DateTime.Now;
            this.database.SaveChanges();
        }

        public void AddErtek(Tipu t)
        {
            Ertek e = new Ertek();
            e.Id = this.database.Erteks.Last().Id + 1;
            e.Mikortol = System.DateTime.Now;
            e.Tipus = t.Id;
            this.database.Erteks.Add(e);
            this.database.SaveChanges();
        }

        public void addTipus(string s)
        {
            Tipu t = new Tipu();
            t.Id = this.database.Tipus.Last().Id;
            t.Leiras = s;
            this.database.Tipus.Add(t);
            this.database.SaveChanges();
        }


        public User getUser(int id)
        {
            return this.database.Users.Where(u => u.Id == id).Last();
        }

        public Belepe GetBelepesek(int id)
        {
            return this.database.Belepes.Where(b => b.Id == id).Last();
        }

        public Berlet getBerlet(int id)
        {
            return this.database.Berlets.Where(a => a.Id == id).Last();
        }

        public Ertek GetErtek(int id)
        {
            return this.database.Erteks.Where(e => e.Id == id).Last();
        }

        public Tipu GetTipu(int id)
        {
            return this.database.Tipus.Where(t => t.Id == id).Last();
        }

        public List<Berlet> GetAbonaments(User u)
        {
            User user = this.database.Users.Include("Vasarolt").Include("Vasarolt.Berlet").Where(us => us.Id == u.Id).Last();
            var abonaments = new List<Berlet>();
            foreach (var vas in user.Vasarolts)
            {
                var abonament = this.database.Berlets.Where(a => a.Id == vas.Id).ToList();
                foreach (var ab in abonament)
                {
                    abonaments.Add(ab);
                }
            }
            return abonaments;
        }

        public List<Berlet> getUserBerletek(User u)
        {
            List<Vasarolt> v = this.database.Vasarolts.Where(va => va.Ki == u.Id).ToList() ?? new List<Vasarolt>();
            List<Berlet> b = new List<Berlet>();
            foreach (Vasarolt vas in v)
            {
                List<Berlet> ber = this.database.Berlets.Where(berr => berr.Id == vas.Milyent).ToList() ?? new List<Berlet>();
                foreach (Berlet egyberlet in ber)
                {
                    b.Add(egyberlet);
                }
            }
            return b;
        }

        public void belepes(Berlet b)
        {
            b.Belepesek_szama = b.Belepesek_szama + 1;
            if (b.Idotartam == b.Belepesek_szama)
            {
                b.Aktiv = false;
            }
            this.database.SaveChanges();
        }

        public void updateUser(User u)
        {
            this.database.SaveChanges();
        }
    }
}
