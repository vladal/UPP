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
	public partial class ИнвентаризацияБракаВПроизводстве:ДокументМенеджер
	{
		
		public static ДокументыСсылка.ИнвентаризацияБракаВПроизводстве НайтиПоСсылке(Guid _Ссылка)
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
					,_Fld5080RRef [Подразделение]
					,_Fld5081RRef [Организация]
					,_Fld5082 [Комментарий]
					,_Fld5083RRef [Ответственный]
					,_Fld5084 [ОтражатьВУправленческомУчете]
					,_Fld5085 [ОтражатьВБухгалтерскомУчете]
					,_Fld5086 [ОтражатьВНалоговомУчете]
					,_Fld5087RRef [Заказ]
					,_Fld5089RRef [НоменклатурнаяГруппа]
					,_Fld5091RRef [ПодразделениеОрганизации]
					From _Document288(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ИнвентаризацияБракаВПроизводстве();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(5);
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.Заказ = V82.ДокументыСсылка.ЗаказПокупателя.ВзятьИзКэша((byte[])Читалка.GetValue(10));
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
		
		public static ДокументыСсылка.ИнвентаризацияБракаВПроизводстве НайтиПоНомеру(string Номер)
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
					,_Fld5080RRef [Подразделение]
					,_Fld5081RRef [Организация]
					,_Fld5082 [Комментарий]
					,_Fld5083RRef [Ответственный]
					,_Fld5084 [ОтражатьВУправленческомУчете]
					,_Fld5085 [ОтражатьВБухгалтерскомУчете]
					,_Fld5086 [ОтражатьВНалоговомУчете]
					,_Fld5087RRef [Заказ]
					,_Fld5089RRef [НоменклатурнаяГруппа]
					,_Fld5091RRef [ПодразделениеОрганизации]
					From _Document288(NOLOCK)
					Where _Number = @Номер";
					Команда.Parameters.AddWithValue("Номер", Номер);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ИнвентаризацияБракаВПроизводстве();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(5);
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.Заказ = V82.ДокументыСсылка.ЗаказПокупателя.ВзятьИзКэша((byte[])Читалка.GetValue(10));
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
		
		public static ДокументыВыборка.ИнвентаризацияБракаВПроизводстве Выбрать()
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
					,_Fld5080RRef [Подразделение]
					,_Fld5081RRef [Организация]
					,_Fld5082 [Комментарий]
					,_Fld5083RRef [Ответственный]
					,_Fld5084 [ОтражатьВУправленческомУчете]
					,_Fld5085 [ОтражатьВБухгалтерскомУчете]
					,_Fld5086 [ОтражатьВНалоговомУчете]
					,_Fld5087RRef [Заказ]
					,_Fld5089RRef [НоменклатурнаяГруппа]
					,_Fld5091RRef [ПодразделениеОрганизации]
					From _Document288(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ИнвентаризацияБракаВПроизводстве();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ИнвентаризацияБракаВПроизводстве();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(5);
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.Заказ = V82.ДокументыСсылка.ЗаказПокупателя.ВзятьИзКэша((byte[])Читалка.GetValue(10));
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ИнвентаризацияБракаВПроизводстве ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
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
					,_Fld5080RRef [Подразделение]
					,_Fld5081RRef [Организация]
					,_Fld5082 [Комментарий]
					,_Fld5083RRef [Ответственный]
					,_Fld5084 [ОтражатьВУправленческомУчете]
					,_Fld5085 [ОтражатьВБухгалтерскомУчете]
					,_Fld5086 [ОтражатьВНалоговомУчете]
					,_Fld5087RRef [Заказ]
					,_Fld5089RRef [НоменклатурнаяГруппа]
					,_Fld5091RRef [ПодразделениеОрганизации]
					From _Document288(NOLOCK)
					Where _IDRRef between @Мин and @Макс
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.ИнвентаризацияБракаВПроизводстве();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ИнвентаризацияБракаВПроизводстве();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(5);
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.Заказ = V82.ДокументыСсылка.ЗаказПокупателя.ВзятьИзКэша((byte[])Читалка.GetValue(10));
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ИнвентаризацияБракаВПроизводстве ВыбратьПоНомеру(int Первые,string Мин,string Макс)
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
					,_Fld5080RRef [Подразделение]
					,_Fld5081RRef [Организация]
					,_Fld5082 [Комментарий]
					,_Fld5083RRef [Ответственный]
					,_Fld5084 [ОтражатьВУправленческомУчете]
					,_Fld5085 [ОтражатьВБухгалтерскомУчете]
					,_Fld5086 [ОтражатьВНалоговомУчете]
					,_Fld5087RRef [Заказ]
					,_Fld5089RRef [НоменклатурнаяГруппа]
					,_Fld5091RRef [ПодразделениеОрганизации]
					From _Document288(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.ИнвентаризацияБракаВПроизводстве();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ИнвентаризацияБракаВПроизводстве();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(5);
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.Заказ = V82.ДокументыСсылка.ЗаказПокупателя.ВзятьИзКэша((byte[])Читалка.GetValue(10));
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ИнвентаризацияБракаВПроизводстве СтраницаПоСсылке(int Размер,int Номер)
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
					,_Fld5080RRef [Подразделение]
					,_Fld5081RRef [Организация]
					,_Fld5082 [Комментарий]
					,_Fld5083RRef [Ответственный]
					,_Fld5084 [ОтражатьВУправленческомУчете]
					,_Fld5085 [ОтражатьВБухгалтерскомУчете]
					,_Fld5086 [ОтражатьВНалоговомУчете]
					,_Fld5087RRef [Заказ]
					,_Fld5089RRef [НоменклатурнаяГруппа]
					,_Fld5091RRef [ПодразделениеОрганизации]
					From _Document288(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ИнвентаризацияБракаВПроизводстве();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ИнвентаризацияБракаВПроизводстве();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(5);
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.Заказ = V82.ДокументыСсылка.ЗаказПокупателя.ВзятьИзКэша((byte[])Читалка.GetValue(10));
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ИнвентаризацияБракаВПроизводстве СтраницаПоНомеру(int Размер,int Номер)
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
					,_Fld5080RRef [Подразделение]
					,_Fld5081RRef [Организация]
					,_Fld5082 [Комментарий]
					,_Fld5083RRef [Ответственный]
					,_Fld5084 [ОтражатьВУправленческомУчете]
					,_Fld5085 [ОтражатьВБухгалтерскомУчете]
					,_Fld5086 [ОтражатьВНалоговомУчете]
					,_Fld5087RRef [Заказ]
					,_Fld5089RRef [НоменклатурнаяГруппа]
					,_Fld5091RRef [ПодразделениеОрганизации]
					From _Document288(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ИнвентаризацияБракаВПроизводстве();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ИнвентаризацияБракаВПроизводстве();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(5);
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.Заказ = V82.ДокументыСсылка.ЗаказПокупателя.ВзятьИзКэша((byte[])Читалка.GetValue(10));
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static V82.ДокументыОбъект.ИнвентаризацияБракаВПроизводстве СоздатьЭлемент()
		{
			var Объект = new V82.ДокументыОбъект.ИнвентаризацияБракаВПроизводстве();
			Объект._ЭтоНовый = true;
			Объект.Ссылка = Guid.NewGuid();/*http://msdn.microsoft.com/ru-ru/library/aa379322(VS.85).aspx*/
			Объект.Комментарий = "";
			Объект.Заказ = new V82.ДокументыСсылка.ЗаказПокупателя();
			return Объект;
		}
	}
}