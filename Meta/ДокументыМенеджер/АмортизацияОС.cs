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
	public partial class АмортизацияОС:ДокументМенеджер
	{
		
		public static ДокументыСсылка.АмортизацияОС НайтиПоСсылке(Guid _Ссылка)
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
					,_Fld2813 [Комментарий]
					,_Fld2814RRef [Организация]
					,_Fld2815RRef [Ответственный]
					,_Fld2816 [ОтражатьВБухгалтерскомУчете]
					,_Fld2817 [ОтражатьВНалоговомУчете]
					,_Fld2818 [ОтражатьВУправленческомУчете]
					,_Fld2819 [ПериодРегистрации]
					From _Document211(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.АмортизацияОС();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(3);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(9);
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
		
		public static ДокументыСсылка.АмортизацияОС НайтиПоНомеру(string Номер)
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
					,_Fld2813 [Комментарий]
					,_Fld2814RRef [Организация]
					,_Fld2815RRef [Ответственный]
					,_Fld2816 [ОтражатьВБухгалтерскомУчете]
					,_Fld2817 [ОтражатьВНалоговомУчете]
					,_Fld2818 [ОтражатьВУправленческомУчете]
					,_Fld2819 [ПериодРегистрации]
					From _Document211(NOLOCK)
					Where _Number = @Номер";
					Команда.Parameters.AddWithValue("Номер", Номер);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.АмортизацияОС();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(3);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(9);
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
		
		public static ДокументыВыборка.АмортизацияОС Выбрать()
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
					,_Fld2813 [Комментарий]
					,_Fld2814RRef [Организация]
					,_Fld2815RRef [Ответственный]
					,_Fld2816 [ОтражатьВБухгалтерскомУчете]
					,_Fld2817 [ОтражатьВНалоговомУчете]
					,_Fld2818 [ОтражатьВУправленческомУчете]
					,_Fld2819 [ПериодРегистрации]
					From _Document211(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.АмортизацияОС();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.АмортизацияОС();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(3);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(9);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.АмортизацияОС ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
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
					,_Fld2813 [Комментарий]
					,_Fld2814RRef [Организация]
					,_Fld2815RRef [Ответственный]
					,_Fld2816 [ОтражатьВБухгалтерскомУчете]
					,_Fld2817 [ОтражатьВНалоговомУчете]
					,_Fld2818 [ОтражатьВУправленческомУчете]
					,_Fld2819 [ПериодРегистрации]
					From _Document211(NOLOCK)
					Where _IDRRef between @Мин and @Макс
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.АмортизацияОС();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.АмортизацияОС();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(3);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(9);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.АмортизацияОС ВыбратьПоНомеру(int Первые,string Мин,string Макс)
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
					,_Fld2813 [Комментарий]
					,_Fld2814RRef [Организация]
					,_Fld2815RRef [Ответственный]
					,_Fld2816 [ОтражатьВБухгалтерскомУчете]
					,_Fld2817 [ОтражатьВНалоговомУчете]
					,_Fld2818 [ОтражатьВУправленческомУчете]
					,_Fld2819 [ПериодРегистрации]
					From _Document211(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.АмортизацияОС();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.АмортизацияОС();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(3);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(9);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.АмортизацияОС СтраницаПоСсылке(int Размер,int Номер)
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
					,_Fld2813 [Комментарий]
					,_Fld2814RRef [Организация]
					,_Fld2815RRef [Ответственный]
					,_Fld2816 [ОтражатьВБухгалтерскомУчете]
					,_Fld2817 [ОтражатьВНалоговомУчете]
					,_Fld2818 [ОтражатьВУправленческомУчете]
					,_Fld2819 [ПериодРегистрации]
					From _Document211(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.АмортизацияОС();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.АмортизацияОС();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(3);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(9);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.АмортизацияОС СтраницаПоНомеру(int Размер,int Номер)
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
					,_Fld2813 [Комментарий]
					,_Fld2814RRef [Организация]
					,_Fld2815RRef [Ответственный]
					,_Fld2816 [ОтражатьВБухгалтерскомУчете]
					,_Fld2817 [ОтражатьВНалоговомУчете]
					,_Fld2818 [ОтражатьВУправленческомУчете]
					,_Fld2819 [ПериодРегистрации]
					From _Document211(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.АмортизацияОС();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.АмортизацияОС();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(3);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(9);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static V82.ДокументыОбъект.АмортизацияОС СоздатьЭлемент()
		{
			var Объект = new V82.ДокументыОбъект.АмортизацияОС();
			Объект._ЭтоНовый = true;
			Объект.Ссылка = Guid.NewGuid();/*http://msdn.microsoft.com/ru-ru/library/aa379322(VS.85).aspx*/
			Объект.Комментарий = "";
			return Объект;
		}
	}
}