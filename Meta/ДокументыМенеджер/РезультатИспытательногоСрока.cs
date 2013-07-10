﻿
using System;
using System.Data.SqlClient;
using V82;
using V82.ДокументыСсылка;
using V82.Документы;//Менеджер;
using V82.ДокументыСсылка;
using V82.Перечисления;//Ссылка;
namespace V82.Документы//Менеджер
{
	///<summary>
	///(Общ)
	///</summary>
	public partial class РезультатИспытательногоСрока:ДокументМенеджер
	{
		
		public static ДокументыСсылка.РезультатИспытательногоСрока НайтиПоСсылке(Guid _Ссылка)
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
					,_Fld7741 [Комментарий]
					,_Fld7742RRef [Ответственный]
					,_Fld22028RRef [Сотрудник]
					,_Fld22029RRef [ФизЛицо]
					,_Fld22030RRef [Результат]
					,_Fld22031 [УдалитьКраткийСоставДокумента]
					,_Fld22032 [ДатаИзменения]
					From _Document358(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РезультатИспытательногоСрока();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(3);
							Ссылка.Результат = V82.Перечисления/*Ссылка*/.РезультатыИспытательногоСрока.ПустаяСсылка.Получить((byte[])Читалка.GetValue(7));
							Ссылка.УдалитьКраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.ДатаИзменения = Читалка.GetDateTime(9);
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
		
		public static ДокументыСсылка.РезультатИспытательногоСрока НайтиПоНомеру(string Номер)
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
					,_Fld7741 [Комментарий]
					,_Fld7742RRef [Ответственный]
					,_Fld22028RRef [Сотрудник]
					,_Fld22029RRef [ФизЛицо]
					,_Fld22030RRef [Результат]
					,_Fld22031 [УдалитьКраткийСоставДокумента]
					,_Fld22032 [ДатаИзменения]
					From _Document358(NOLOCK)
					Where _Number = @Номер";
					Команда.Parameters.AddWithValue("Номер", Номер);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РезультатИспытательногоСрока();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(3);
							Ссылка.Результат = V82.Перечисления/*Ссылка*/.РезультатыИспытательногоСрока.ПустаяСсылка.Получить((byte[])Читалка.GetValue(7));
							Ссылка.УдалитьКраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.ДатаИзменения = Читалка.GetDateTime(9);
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
		
		public static ДокументыВыборка.РезультатИспытательногоСрока Выбрать()
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
					,_Fld7741 [Комментарий]
					,_Fld7742RRef [Ответственный]
					,_Fld22028RRef [Сотрудник]
					,_Fld22029RRef [ФизЛицо]
					,_Fld22030RRef [Результат]
					,_Fld22031 [УдалитьКраткийСоставДокумента]
					,_Fld22032 [ДатаИзменения]
					From _Document358(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.РезультатИспытательногоСрока();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РезультатИспытательногоСрока();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(3);
							Ссылка.Результат = V82.Перечисления/*Ссылка*/.РезультатыИспытательногоСрока.ПустаяСсылка.Получить((byte[])Читалка.GetValue(7));
							Ссылка.УдалитьКраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.ДатаИзменения = Читалка.GetDateTime(9);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.РезультатИспытательногоСрока ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
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
					,_Fld7741 [Комментарий]
					,_Fld7742RRef [Ответственный]
					,_Fld22028RRef [Сотрудник]
					,_Fld22029RRef [ФизЛицо]
					,_Fld22030RRef [Результат]
					,_Fld22031 [УдалитьКраткийСоставДокумента]
					,_Fld22032 [ДатаИзменения]
					From _Document358(NOLOCK)
					Where _IDRRef between @Мин and @Макс
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.РезультатИспытательногоСрока();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РезультатИспытательногоСрока();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(3);
							Ссылка.Результат = V82.Перечисления/*Ссылка*/.РезультатыИспытательногоСрока.ПустаяСсылка.Получить((byte[])Читалка.GetValue(7));
							Ссылка.УдалитьКраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.ДатаИзменения = Читалка.GetDateTime(9);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.РезультатИспытательногоСрока ВыбратьПоНомеру(int Первые,string Мин,string Макс)
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
					,_Fld7741 [Комментарий]
					,_Fld7742RRef [Ответственный]
					,_Fld22028RRef [Сотрудник]
					,_Fld22029RRef [ФизЛицо]
					,_Fld22030RRef [Результат]
					,_Fld22031 [УдалитьКраткийСоставДокумента]
					,_Fld22032 [ДатаИзменения]
					From _Document358(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.РезультатИспытательногоСрока();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РезультатИспытательногоСрока();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(3);
							Ссылка.Результат = V82.Перечисления/*Ссылка*/.РезультатыИспытательногоСрока.ПустаяСсылка.Получить((byte[])Читалка.GetValue(7));
							Ссылка.УдалитьКраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.ДатаИзменения = Читалка.GetDateTime(9);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.РезультатИспытательногоСрока СтраницаПоСсылке(int Размер,int Номер)
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
					,_Fld7741 [Комментарий]
					,_Fld7742RRef [Ответственный]
					,_Fld22028RRef [Сотрудник]
					,_Fld22029RRef [ФизЛицо]
					,_Fld22030RRef [Результат]
					,_Fld22031 [УдалитьКраткийСоставДокумента]
					,_Fld22032 [ДатаИзменения]
					From _Document358(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.РезультатИспытательногоСрока();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РезультатИспытательногоСрока();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(3);
							Ссылка.Результат = V82.Перечисления/*Ссылка*/.РезультатыИспытательногоСрока.ПустаяСсылка.Получить((byte[])Читалка.GetValue(7));
							Ссылка.УдалитьКраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.ДатаИзменения = Читалка.GetDateTime(9);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.РезультатИспытательногоСрока СтраницаПоНомеру(int Размер,int Номер)
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
					,_Fld7741 [Комментарий]
					,_Fld7742RRef [Ответственный]
					,_Fld22028RRef [Сотрудник]
					,_Fld22029RRef [ФизЛицо]
					,_Fld22030RRef [Результат]
					,_Fld22031 [УдалитьКраткийСоставДокумента]
					,_Fld22032 [ДатаИзменения]
					From _Document358(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.РезультатИспытательногоСрока();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РезультатИспытательногоСрока();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(3);
							Ссылка.Результат = V82.Перечисления/*Ссылка*/.РезультатыИспытательногоСрока.ПустаяСсылка.Получить((byte[])Читалка.GetValue(7));
							Ссылка.УдалитьКраткийСоставДокумента = Читалка.GetString(8);
							Ссылка.ДатаИзменения = Читалка.GetDateTime(9);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static V82.ДокументыОбъект.РезультатИспытательногоСрока СоздатьЭлемент()
		{
			var Объект = new V82.ДокументыОбъект.РезультатИспытательногоСрока();
			Объект._ЭтоНовый = true;
			Объект.Ссылка = Guid.NewGuid();/*http://msdn.microsoft.com/ru-ru/library/aa379322(VS.85).aspx*/
			Объект.Комментарий = "";
			Объект.УдалитьКраткийСоставДокумента = "";
			Объект.Результат = V82.Перечисления/*Ссылка*/.РезультатыИспытательногоСрока.ПустаяСсылка;
			return Объект;
		}
	}
}