using MVCMedicalController.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCMedicalController.Models;

namespace MVCMedicalController.Controllers
{
    public class DbIni
    {
        public static void Initialize(MedControlContext context)
        {
            // Look for any students.
            if (context.Doctor.Any())
            {
                return;   // DB has been seeded
            }

            var cabinets = new Cabinet[]
            {
                new Cabinet{CabinetNumber = "Кабинет 1"},
                new Cabinet{CabinetNumber = "Кабинет 2"},
                new Cabinet{CabinetNumber = "Кабинет 3"},
                new Cabinet{CabinetNumber = "Кабинет 4"},
                new Cabinet{CabinetNumber = "Кабинет 5"},
                new Cabinet{CabinetNumber = "Кабинет 6"},
                new Cabinet{CabinetNumber = "Кабинет 7"},
                new Cabinet{CabinetNumber = "Кабинет 8"},

            };

            context.Cabinet.AddRange(cabinets);
            context.SaveChanges();

            

            var sector = new Sector[]
            {
                new Sector{Title = "Участок 1"},
                new Sector{Title = "Участок 2"},
                new Sector{Title = "Участок 3"},
                new Sector{Title = "Участок 4"},
                new Sector{Title = "Участок 5"},
                new Sector{Title = "Участок 6"},
                new Sector{Title = "Участок 7"},
                new Sector{Title = "Участок 8"},

            };

            context.Sector.AddRange(sector);
            context.SaveChanges();

            var patients = new Patient[]
            {
                new Patient{ PatientSoName = "Иванов 1", PatientName = "Иванов 1", PatientFatherName = "Иванов 1", Adress = "Адрес 1", DateOfBirth = DateTime.Today, Sex = "муж", Sectors = sector[0] },
                new Patient{ PatientSoName = "Иванов 2", PatientName = "Иванов 2", PatientFatherName = "Иванов 2", Adress = "Адрес 2", DateOfBirth = DateTime.Today, Sex = "муж", Sectors = sector[1] },
                new Patient{ PatientSoName = "Иванов 3", PatientName = "Иванов 3", PatientFatherName = "Иванов 3", Adress = "Адрес 3", DateOfBirth = DateTime.Today, Sex = "муж", Sectors = sector[2] },
                new Patient{ PatientSoName = "Иванов 4", PatientName = "Иванов 4", PatientFatherName = "Иванов 4", Adress = "Адрес 4", DateOfBirth = DateTime.Today, Sex = "муж", Sectors = sector[3] },
                new Patient{ PatientSoName = "Иванов 5", PatientName = "Иванов 5", PatientFatherName = "Иванов 5", Adress = "Адрес 5", DateOfBirth = DateTime.Today, Sex = "муж", Sectors = sector[4] },
                new Patient{ PatientSoName = "Иванов 6", PatientName = "Иванов 6", PatientFatherName = "Иванов 6", Adress = "Адрес 6", DateOfBirth = DateTime.Today, Sex = "муж", Sectors = sector[5] },
                new Patient{ PatientSoName = "Иванов 7", PatientName = "Иванов 7", PatientFatherName = "Иванов 7", Adress = "Адрес 7", DateOfBirth = DateTime.Today, Sex = "муж", Sectors = sector[6] },
            };

            context.Patient.AddRange(patients);
            context.SaveChanges();

            

            var spec = new Speciality[]
            {
                new Speciality{SpecialityName = "Терапевт 1"},
                new Speciality{SpecialityName = "Терапевт 2"},
                new Speciality{SpecialityName = "Терапевт 3"},
                new Speciality{SpecialityName = "Терапевт 4"},
                new Speciality{SpecialityName = "Терапевт 5"},
                new Speciality{SpecialityName = "Терапевт 6"},
                new Speciality{SpecialityName = "Терапевт 7"},
                new Speciality{SpecialityName = "Терапевт 8"},
                new Speciality{SpecialityName = "Терапевт 9"},
                new Speciality{SpecialityName = "Терапевт 10"},

            };

            context.Speciality.AddRange(spec);
            context.SaveChanges();


            var doctors = new Doctor[]
            {
                new Doctor { DoctorSoName = "Петров 1", DoctorName = "Петр 1", DoctorFatherName = "Петрович 1", Cabinets = cabinets[0], Specialitys = spec[0], Sectors = sector[0] },
                new Doctor { DoctorSoName = "Петров 2", DoctorName = "Петр 2", DoctorFatherName = "Петрович 2", Cabinets = cabinets[1], Specialitys = spec[1], Sectors = sector[1] },
                new Doctor { DoctorSoName = "Петров 3", DoctorName = "Петр 3", DoctorFatherName = "Петрович 3", Cabinets = cabinets[2], Specialitys = spec[2], Sectors = sector[2] },
                new Doctor { DoctorSoName = "Петров 4", DoctorName = "Петр 4", DoctorFatherName = "Петрович 4", Cabinets = cabinets[3], Specialitys = spec[3], Sectors = sector[3] },
                new Doctor { DoctorSoName = "Петров 5", DoctorName = "Петр 5", DoctorFatherName = "Петрович 5", Cabinets = cabinets[4], Specialitys = spec[4], Sectors = sector[4] },
                new Doctor { DoctorSoName = "Петров 6", DoctorName = "Петр 6", DoctorFatherName = "Петрович 6", Cabinets = cabinets[5], Specialitys = spec[5], Sectors = sector[5] },
                new Doctor { DoctorSoName = "Петров 7", DoctorName = "Петр 7", DoctorFatherName = "Петрович 7", Cabinets = cabinets[6], Specialitys = spec[6], Sectors = sector[6] }

            };

            context.Doctor.AddRange(doctors);
            context.SaveChanges();

        }
    }
}
