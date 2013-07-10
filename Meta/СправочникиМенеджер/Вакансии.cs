﻿
using System;
using System.Data.SqlClient;
using V82;
using V82.СправочникиСсылка;
using V82.Справочники;//Менеджер;
using V82.ДокументыСсылка;
using V82.Перечисления;//Ссылка;
namespace V82.Справочники//Менеджер
{
	public partial class Вакансии:СправочникМенеджер
	{
		
		public static СправочникиСсылка.Вакансии НайтиПоСсылке(Guid _Ссылка)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_IsMetadata [Предопределенный]
					,_Code [Код]
					,_Description [Наименование]
					,_Fld19717 [Закрыта]
					,_Fld19718RRef [Должность]
					,_Fld19719RRef [Заявитель]
					,_Fld19720 [Обязанности]
					,_Fld19721RRef [Организация]
					,_Fld19722RRef [Ответственный]
					,_Fld19723 [ПлановаяДатаЗакрытия]
					,_Fld19724_TYPE [Подразделение_Тип],_Fld19724_RRRef [Подразделение],_Fld19724_RTRef [Подразделение_Вид]
					,_Fld19725 [Требования]
					,_Fld19726 [Условия]
					,_Fld19727 [ДатаОткрытия]
					,_Fld19728 [ДатаЗакрытия]
					From _Reference19631(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new СправочникиСсылка.Вакансии();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Предопределенный = ((byte[])Читалка.GetValue(3))[0]==1;
							Ссылка.Код = Читалка.GetString(4);
							Ссылка.Наименование = Читалка.GetString(5);
							Ссылка.Закрыта = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.Должность = V82.СправочникиСсылка.Должности.ВзятьИзКэша((byte[])Читалка.GetValue(7));
							Ссылка.Заявитель = V82.СправочникиСсылка.Пользователи.ВзятьИзКэша((byte[])Читалка.GetValue(8));
							Ссылка.Обязанности = Читалка.GetString(9);
							Ссылка.Организация = V82.СправочникиСсылка.Организации.ВзятьИзКэша((byte[])Читалка.GetValue(10));
							Ссылка.Ответственный = V82.СправочникиСсылка.Пользователи.ВзятьИзКэша((byte[])Читалка.GetValue(11));
							Ссылка.ПлановаяДатаЗакрытия = Читалка.GetDateTime(12);
							Ссылка.Требования = Читалка.GetString(16);
							Ссылка.Условия = Читалка.GetString(17);
							Ссылка.ДатаОткрытия = Читалка.GetDateTime(18);
							Ссылка.ДатаЗакрытия = Читалка.GetDateTime(19);
							return Ссылка;
						}
						else
						{
							return null;
						}
					}
				}
			}
		}
		
		public static СправочникиСсылка.Вакансии НайтиПоКоду(string Код)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_IsMetadata [Предопределенный]
					,_Code [Код]
					,_Description [Наименование]
					,_Fld19717 [Закрыта]
					,_Fld19718RRef [Должность]
					,_Fld19719RRef [Заявитель]
					,_Fld19720 [Обязанности]
					,_Fld19721RRef [Организация]
					,_Fld19722RRef [Ответственный]
					,_Fld19723 [ПлановаяДатаЗакрытия]
					,_Fld19724_TYPE [Подразделение_Тип],_Fld19724_RRRef [Подразделение],_Fld19724_RTRef [Подразделение_Вид]
					,_Fld19725 [Требования]
					,_Fld19726 [Условия]
					,_Fld19727 [ДатаОткрытия]
					,_Fld19728 [ДатаЗакрытия]
					From _Reference19631(NOLOCK)
					Where _Code=@Код";
					Команда.Parameters.AddWithValue("Код", Код);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new СправочникиСсылка.Вакансии();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Предопределенный = ((byte[])Читалка.GetValue(3))[0]==1;
							Ссылка.Код = Читалка.GetString(4);
							Ссылка.Наименование = Читалка.GetString(5);
							Ссылка.Закрыта = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.Должность = V82.СправочникиСсылка.Должности.ВзятьИзКэша((byte[])Читалка.GetValue(7));
							Ссылка.Заявитель = V82.СправочникиСсылка.Пользователи.ВзятьИзКэша((byte[])Читалка.GetValue(8));
							Ссылка.Обязанности = Читалка.GetString(9);
							Ссылка.Организация = V82.СправочникиСсылка.Организации.ВзятьИзКэша((byte[])Читалка.GetValue(10));
							Ссылка.Ответственный = V82.СправочникиСсылка.Пользователи.ВзятьИзКэша((byte[])Читалка.GetValue(11));
							Ссылка.ПлановаяДатаЗакрытия = Читалка.GetDateTime(12);
							Ссылка.Требования = Читалка.GetString(16);
							Ссылка.Условия = Читалка.GetString(17);
							Ссылка.ДатаОткрытия = Читалка.GetDateTime(18);
							Ссылка.ДатаЗакрытия = Читалка.GetDateTime(19);
							return Ссылка;
						}
						else
						{
							return null;
						}
					}
				}
			}
		}
		
		public static СправочникиВыборка.Вакансии Выбрать()
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1000 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_IsMetadata [Предопределенный]
					,_Code [Код]
					,_Description [Наименование]
					,_Fld19717 [Закрыта]
					,_Fld19718RRef [Должность]
					,_Fld19719RRef [Заявитель]
					,_Fld19720 [Обязанности]
					,_Fld19721RRef [Организация]
					,_Fld19722RRef [Ответственный]
					,_Fld19723 [ПлановаяДатаЗакрытия]
					,_Fld19724_TYPE [Подразделение_Тип],_Fld19724_RRRef [Подразделение],_Fld19724_RTRef [Подразделение_Вид]
					,_Fld19725 [Требования]
					,_Fld19726 [Условия]
					,_Fld19727 [ДатаОткрытия]
					,_Fld19728 [ДатаЗакрытия]
					From _Reference19631(NOLOCK) ";
					var Выборка = new V82.СправочникиВыборка.Вакансии();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new СправочникиСсылка.Вакансии();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Предопределенный = ((byte[])Читалка.GetValue(3))[0]==1;
							Ссылка.Код = Читалка.GetString(4);
							Ссылка.Наименование = Читалка.GetString(5);
							Ссылка.Закрыта = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.Должность = V82.СправочникиСсылка.Должности.ВзятьИзКэша((byte[])Читалка.GetValue(7));
							Ссылка.Заявитель = V82.СправочникиСсылка.Пользователи.ВзятьИзКэша((byte[])Читалка.GetValue(8));
							Ссылка.Обязанности = Читалка.GetString(9);
							Ссылка.Организация = V82.СправочникиСсылка.Организации.ВзятьИзКэша((byte[])Читалка.GetValue(10));
							Ссылка.Ответственный = V82.СправочникиСсылка.Пользователи.ВзятьИзКэша((byte[])Читалка.GetValue(11));
							Ссылка.ПлановаяДатаЗакрытия = Читалка.GetDateTime(12);
							Ссылка.Требования = Читалка.GetString(16);
							Ссылка.Условия = Читалка.GetString(17);
							Ссылка.ДатаОткрытия = Читалка.GetDateTime(18);
							Ссылка.ДатаЗакрытия = Читалка.GetDateTime(19);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static СправочникиВыборка.Вакансии ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = string.Format(@"Select top {0} 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_IsMetadata [Предопределенный]
					,_Code [Код]
					,_Description [Наименование]
					,_Fld19717 [Закрыта]
					,_Fld19718RRef [Должность]
					,_Fld19719RRef [Заявитель]
					,_Fld19720 [Обязанности]
					,_Fld19721RRef [Организация]
					,_Fld19722RRef [Ответственный]
					,_Fld19723 [ПлановаяДатаЗакрытия]
					,_Fld19724_TYPE [Подразделение_Тип],_Fld19724_RRRef [Подразделение],_Fld19724_RTRef [Подразделение_Вид]
					,_Fld19725 [Требования]
					,_Fld19726 [Условия]
					,_Fld19727 [ДатаОткрытия]
					,_Fld19728 [ДатаЗакрытия]
					From _Reference19631(NOLOCK)
					Where _IDRRef between @Мин and @Макс 
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.СправочникиВыборка.Вакансии();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new СправочникиСсылка.Вакансии();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Предопределенный = ((byte[])Читалка.GetValue(3))[0]==1;
							Ссылка.Код = Читалка.GetString(4);
							Ссылка.Наименование = Читалка.GetString(5);
							Ссылка.Закрыта = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.Должность = V82.СправочникиСсылка.Должности.ВзятьИзКэша((byte[])Читалка.GetValue(7));
							Ссылка.Заявитель = V82.СправочникиСсылка.Пользователи.ВзятьИзКэша((byte[])Читалка.GetValue(8));
							Ссылка.Обязанности = Читалка.GetString(9);
							Ссылка.Организация = V82.СправочникиСсылка.Организации.ВзятьИзКэша((byte[])Читалка.GetValue(10));
							Ссылка.Ответственный = V82.СправочникиСсылка.Пользователи.ВзятьИзКэша((byte[])Читалка.GetValue(11));
							Ссылка.ПлановаяДатаЗакрытия = Читалка.GetDateTime(12);
							Ссылка.Требования = Читалка.GetString(16);
							Ссылка.Условия = Читалка.GetString(17);
							Ссылка.ДатаОткрытия = Читалка.GetDateTime(18);
							Ссылка.ДатаЗакрытия = Читалка.GetDateTime(19);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static СправочникиВыборка.Вакансии ВыбратьПоКоду(int Первые,string Мин,string Макс)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = string.Format(@"Select top {0} 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_IsMetadata [Предопределенный]
					,_Code [Код]
					,_Description [Наименование]
					,_Fld19717 [Закрыта]
					,_Fld19718RRef [Должность]
					,_Fld19719RRef [Заявитель]
					,_Fld19720 [Обязанности]
					,_Fld19721RRef [Организация]
					,_Fld19722RRef [Ответственный]
					,_Fld19723 [ПлановаяДатаЗакрытия]
					,_Fld19724_TYPE [Подразделение_Тип],_Fld19724_RRRef [Подразделение],_Fld19724_RTRef [Подразделение_Вид]
					,_Fld19725 [Требования]
					,_Fld19726 [Условия]
					,_Fld19727 [ДатаОткрытия]
					,_Fld19728 [ДатаЗакрытия]
					From _Reference19631(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.СправочникиВыборка.Вакансии();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new СправочникиСсылка.Вакансии();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Предопределенный = ((byte[])Читалка.GetValue(3))[0]==1;
							Ссылка.Код = Читалка.GetString(4);
							Ссылка.Наименование = Читалка.GetString(5);
							Ссылка.Закрыта = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.Должность = V82.СправочникиСсылка.Должности.ВзятьИзКэша((byte[])Читалка.GetValue(7));
							Ссылка.Заявитель = V82.СправочникиСсылка.Пользователи.ВзятьИзКэша((byte[])Читалка.GetValue(8));
							Ссылка.Обязанности = Читалка.GetString(9);
							Ссылка.Организация = V82.СправочникиСсылка.Организации.ВзятьИзКэша((byte[])Читалка.GetValue(10));
							Ссылка.Ответственный = V82.СправочникиСсылка.Пользователи.ВзятьИзКэша((byte[])Читалка.GetValue(11));
							Ссылка.ПлановаяДатаЗакрытия = Читалка.GetDateTime(12);
							Ссылка.Требования = Читалка.GetString(16);
							Ссылка.Условия = Читалка.GetString(17);
							Ссылка.ДатаОткрытия = Читалка.GetDateTime(18);
							Ссылка.ДатаЗакрытия = Читалка.GetDateTime(19);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static СправочникиВыборка.Вакансии ВыбратьПоНаименованию(int Первые,string Мин,string Макс)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = string.Format(@"Select top {0} 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_IsMetadata [Предопределенный]
					,_Code [Код]
					,_Description [Наименование]
					,_Fld19717 [Закрыта]
					,_Fld19718RRef [Должность]
					,_Fld19719RRef [Заявитель]
					,_Fld19720 [Обязанности]
					,_Fld19721RRef [Организация]
					,_Fld19722RRef [Ответственный]
					,_Fld19723 [ПлановаяДатаЗакрытия]
					,_Fld19724_TYPE [Подразделение_Тип],_Fld19724_RRRef [Подразделение],_Fld19724_RTRef [Подразделение_Вид]
					,_Fld19725 [Требования]
					,_Fld19726 [Условия]
					,_Fld19727 [ДатаОткрытия]
					,_Fld19728 [ДатаЗакрытия]
					From _Reference19631(NOLOCK)
					Where _Description between @Мин and @Макс
					Order by _Description", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.СправочникиВыборка.Вакансии();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new СправочникиСсылка.Вакансии();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Предопределенный = ((byte[])Читалка.GetValue(3))[0]==1;
							Ссылка.Код = Читалка.GetString(4);
							Ссылка.Наименование = Читалка.GetString(5);
							Ссылка.Закрыта = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.Должность = V82.СправочникиСсылка.Должности.ВзятьИзКэша((byte[])Читалка.GetValue(7));
							Ссылка.Заявитель = V82.СправочникиСсылка.Пользователи.ВзятьИзКэша((byte[])Читалка.GetValue(8));
							Ссылка.Обязанности = Читалка.GetString(9);
							Ссылка.Организация = V82.СправочникиСсылка.Организации.ВзятьИзКэша((byte[])Читалка.GetValue(10));
							Ссылка.Ответственный = V82.СправочникиСсылка.Пользователи.ВзятьИзКэша((byte[])Читалка.GetValue(11));
							Ссылка.ПлановаяДатаЗакрытия = Читалка.GetDateTime(12);
							Ссылка.Требования = Читалка.GetString(16);
							Ссылка.Условия = Читалка.GetString(17);
							Ссылка.ДатаОткрытия = Читалка.GetDateTime(18);
							Ссылка.ДатаЗакрытия = Читалка.GetDateTime(19);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static СправочникиВыборка.Вакансии СтраницаПоСсылке(int Размер,int Номер)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1000 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_IsMetadata [Предопределенный]
					,_Code [Код]
					,_Description [Наименование]
					,_Fld19717 [Закрыта]
					,_Fld19718RRef [Должность]
					,_Fld19719RRef [Заявитель]
					,_Fld19720 [Обязанности]
					,_Fld19721RRef [Организация]
					,_Fld19722RRef [Ответственный]
					,_Fld19723 [ПлановаяДатаЗакрытия]
					,_Fld19724_TYPE [Подразделение_Тип],_Fld19724_RRRef [Подразделение],_Fld19724_RTRef [Подразделение_Вид]
					,_Fld19725 [Требования]
					,_Fld19726 [Условия]
					,_Fld19727 [ДатаОткрытия]
					,_Fld19728 [ДатаЗакрытия]
					From _Reference19631(NOLOCK)";
					var Выборка = new V82.СправочникиВыборка.Вакансии();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new СправочникиСсылка.Вакансии();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Предопределенный = ((byte[])Читалка.GetValue(3))[0]==1;
							Ссылка.Код = Читалка.GetString(4);
							Ссылка.Наименование = Читалка.GetString(5);
							Ссылка.Закрыта = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.Должность = V82.СправочникиСсылка.Должности.ВзятьИзКэша((byte[])Читалка.GetValue(7));
							Ссылка.Заявитель = V82.СправочникиСсылка.Пользователи.ВзятьИзКэша((byte[])Читалка.GetValue(8));
							Ссылка.Обязанности = Читалка.GetString(9);
							Ссылка.Организация = V82.СправочникиСсылка.Организации.ВзятьИзКэша((byte[])Читалка.GetValue(10));
							Ссылка.Ответственный = V82.СправочникиСсылка.Пользователи.ВзятьИзКэша((byte[])Читалка.GetValue(11));
							Ссылка.ПлановаяДатаЗакрытия = Читалка.GetDateTime(12);
							Ссылка.Требования = Читалка.GetString(16);
							Ссылка.Условия = Читалка.GetString(17);
							Ссылка.ДатаОткрытия = Читалка.GetDateTime(18);
							Ссылка.ДатаЗакрытия = Читалка.GetDateTime(19);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static СправочникиВыборка.Вакансии СтраницаПоКоду(int Размер,int Номер)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1000 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_IsMetadata [Предопределенный]
					,_Code [Код]
					,_Description [Наименование]
					,_Fld19717 [Закрыта]
					,_Fld19718RRef [Должность]
					,_Fld19719RRef [Заявитель]
					,_Fld19720 [Обязанности]
					,_Fld19721RRef [Организация]
					,_Fld19722RRef [Ответственный]
					,_Fld19723 [ПлановаяДатаЗакрытия]
					,_Fld19724_TYPE [Подразделение_Тип],_Fld19724_RRRef [Подразделение],_Fld19724_RTRef [Подразделение_Вид]
					,_Fld19725 [Требования]
					,_Fld19726 [Условия]
					,_Fld19727 [ДатаОткрытия]
					,_Fld19728 [ДатаЗакрытия]
					From _Reference19631(NOLOCK)";
					var Выборка = new V82.СправочникиВыборка.Вакансии();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new СправочникиСсылка.Вакансии();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Предопределенный = ((byte[])Читалка.GetValue(3))[0]==1;
							Ссылка.Код = Читалка.GetString(4);
							Ссылка.Наименование = Читалка.GetString(5);
							Ссылка.Закрыта = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.Должность = V82.СправочникиСсылка.Должности.ВзятьИзКэша((byte[])Читалка.GetValue(7));
							Ссылка.Заявитель = V82.СправочникиСсылка.Пользователи.ВзятьИзКэша((byte[])Читалка.GetValue(8));
							Ссылка.Обязанности = Читалка.GetString(9);
							Ссылка.Организация = V82.СправочникиСсылка.Организации.ВзятьИзКэша((byte[])Читалка.GetValue(10));
							Ссылка.Ответственный = V82.СправочникиСсылка.Пользователи.ВзятьИзКэша((byte[])Читалка.GetValue(11));
							Ссылка.ПлановаяДатаЗакрытия = Читалка.GetDateTime(12);
							Ссылка.Требования = Читалка.GetString(16);
							Ссылка.Условия = Читалка.GetString(17);
							Ссылка.ДатаОткрытия = Читалка.GetDateTime(18);
							Ссылка.ДатаЗакрытия = Читалка.GetDateTime(19);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static СправочникиВыборка.Вакансии СтраницаПоНаименованию(int Размер,int Номер)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1000 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_IsMetadata [Предопределенный]
					,_Code [Код]
					,_Description [Наименование]
					,_Fld19717 [Закрыта]
					,_Fld19718RRef [Должность]
					,_Fld19719RRef [Заявитель]
					,_Fld19720 [Обязанности]
					,_Fld19721RRef [Организация]
					,_Fld19722RRef [Ответственный]
					,_Fld19723 [ПлановаяДатаЗакрытия]
					,_Fld19724_TYPE [Подразделение_Тип],_Fld19724_RRRef [Подразделение],_Fld19724_RTRef [Подразделение_Вид]
					,_Fld19725 [Требования]
					,_Fld19726 [Условия]
					,_Fld19727 [ДатаОткрытия]
					,_Fld19728 [ДатаЗакрытия]
					From _Reference19631(NOLOCK)";
					var Выборка = new V82.СправочникиВыборка.Вакансии();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new СправочникиСсылка.Вакансии();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Предопределенный = ((byte[])Читалка.GetValue(3))[0]==1;
							Ссылка.Код = Читалка.GetString(4);
							Ссылка.Наименование = Читалка.GetString(5);
							Ссылка.Закрыта = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.Должность = V82.СправочникиСсылка.Должности.ВзятьИзКэша((byte[])Читалка.GetValue(7));
							Ссылка.Заявитель = V82.СправочникиСсылка.Пользователи.ВзятьИзКэша((byte[])Читалка.GetValue(8));
							Ссылка.Обязанности = Читалка.GetString(9);
							Ссылка.Организация = V82.СправочникиСсылка.Организации.ВзятьИзКэша((byte[])Читалка.GetValue(10));
							Ссылка.Ответственный = V82.СправочникиСсылка.Пользователи.ВзятьИзКэша((byte[])Читалка.GetValue(11));
							Ссылка.ПлановаяДатаЗакрытия = Читалка.GetDateTime(12);
							Ссылка.Требования = Читалка.GetString(16);
							Ссылка.Условия = Читалка.GetString(17);
							Ссылка.ДатаОткрытия = Читалка.GetDateTime(18);
							Ссылка.ДатаЗакрытия = Читалка.GetDateTime(19);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static V82.СправочникиОбъект.Вакансии СоздатьЭлемент()
		{
			var Объект = new V82.СправочникиОбъект.Вакансии();
			Объект._ЭтоНовый = true;
			Объект.Ссылка = Guid.NewGuid();/*http://msdn.microsoft.com/ru-ru/library/aa379322(VS.85).aspx*/
			Объект.Обязанности = "";
			Объект.Требования = "";
			Объект.Условия = "";
			Объект.Должность = new V82.СправочникиСсылка.Должности();
			Объект.Заявитель = new V82.СправочникиСсылка.Пользователи();
			Объект.Организация = new V82.СправочникиСсылка.Организации();
			Объект.Ответственный = new V82.СправочникиСсылка.Пользователи();
			return Объект;
		}
	}
}