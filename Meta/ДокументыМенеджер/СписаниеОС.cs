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
	public partial class СписаниеОС:ДокументМенеджер
	{
		
		public static ДокументыСсылка.СписаниеОС НайтиПоСсылке(Guid _Ссылка)
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
					,_Fld11676RRef [Ответственный]
					,_Fld11674 [Комментарий]
					,_Fld11675RRef [Организация]
					,_Fld11677 [ОтражатьВБухгалтерскомУчете]
					,_Fld11678 [ОтражатьВНалоговомУчете]
					,_Fld11679 [ОтражатьВУправленческомУчете]
					,_Fld11680RRef [ПричинаСписания]
					,_Fld11681RRef [Событие]
					,_Fld11684RRef [СчетСписанияБУ]
					,_Fld11685RRef [СчетСписанияНУ]
					,_Fld11682RRef [СубконтоБУ]
					,_Fld11683RRef [СубконтоНУ]
					,_Fld11686RRef [СобытиеРегл]
					From _Document458(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.СписаниеОС();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
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
		
		public static ДокументыСсылка.СписаниеОС НайтиПоНомеру(string Номер)
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
					,_Fld11676RRef [Ответственный]
					,_Fld11674 [Комментарий]
					,_Fld11675RRef [Организация]
					,_Fld11677 [ОтражатьВБухгалтерскомУчете]
					,_Fld11678 [ОтражатьВНалоговомУчете]
					,_Fld11679 [ОтражатьВУправленческомУчете]
					,_Fld11680RRef [ПричинаСписания]
					,_Fld11681RRef [Событие]
					,_Fld11684RRef [СчетСписанияБУ]
					,_Fld11685RRef [СчетСписанияНУ]
					,_Fld11682RRef [СубконтоБУ]
					,_Fld11683RRef [СубконтоНУ]
					,_Fld11686RRef [СобытиеРегл]
					From _Document458(NOLOCK)
					Where _Number = @Номер";
					Команда.Parameters.AddWithValue("Номер", Номер);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.СписаниеОС();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
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
		
		public static ДокументыВыборка.СписаниеОС Выбрать()
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
					,_Fld11676RRef [Ответственный]
					,_Fld11674 [Комментарий]
					,_Fld11675RRef [Организация]
					,_Fld11677 [ОтражатьВБухгалтерскомУчете]
					,_Fld11678 [ОтражатьВНалоговомУчете]
					,_Fld11679 [ОтражатьВУправленческомУчете]
					,_Fld11680RRef [ПричинаСписания]
					,_Fld11681RRef [Событие]
					,_Fld11684RRef [СчетСписанияБУ]
					,_Fld11685RRef [СчетСписанияНУ]
					,_Fld11682RRef [СубконтоБУ]
					,_Fld11683RRef [СубконтоНУ]
					,_Fld11686RRef [СобытиеРегл]
					From _Document458(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.СписаниеОС();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.СписаниеОС();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.СписаниеОС ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
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
					,_Fld11676RRef [Ответственный]
					,_Fld11674 [Комментарий]
					,_Fld11675RRef [Организация]
					,_Fld11677 [ОтражатьВБухгалтерскомУчете]
					,_Fld11678 [ОтражатьВНалоговомУчете]
					,_Fld11679 [ОтражатьВУправленческомУчете]
					,_Fld11680RRef [ПричинаСписания]
					,_Fld11681RRef [Событие]
					,_Fld11684RRef [СчетСписанияБУ]
					,_Fld11685RRef [СчетСписанияНУ]
					,_Fld11682RRef [СубконтоБУ]
					,_Fld11683RRef [СубконтоНУ]
					,_Fld11686RRef [СобытиеРегл]
					From _Document458(NOLOCK)
					Where _IDRRef between @Мин and @Макс
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.СписаниеОС();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.СписаниеОС();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.СписаниеОС ВыбратьПоНомеру(int Первые,string Мин,string Макс)
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
					,_Fld11676RRef [Ответственный]
					,_Fld11674 [Комментарий]
					,_Fld11675RRef [Организация]
					,_Fld11677 [ОтражатьВБухгалтерскомУчете]
					,_Fld11678 [ОтражатьВНалоговомУчете]
					,_Fld11679 [ОтражатьВУправленческомУчете]
					,_Fld11680RRef [ПричинаСписания]
					,_Fld11681RRef [Событие]
					,_Fld11684RRef [СчетСписанияБУ]
					,_Fld11685RRef [СчетСписанияНУ]
					,_Fld11682RRef [СубконтоБУ]
					,_Fld11683RRef [СубконтоНУ]
					,_Fld11686RRef [СобытиеРегл]
					From _Document458(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.СписаниеОС();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.СписаниеОС();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.СписаниеОС СтраницаПоСсылке(int Размер,int Номер)
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
					,_Fld11676RRef [Ответственный]
					,_Fld11674 [Комментарий]
					,_Fld11675RRef [Организация]
					,_Fld11677 [ОтражатьВБухгалтерскомУчете]
					,_Fld11678 [ОтражатьВНалоговомУчете]
					,_Fld11679 [ОтражатьВУправленческомУчете]
					,_Fld11680RRef [ПричинаСписания]
					,_Fld11681RRef [Событие]
					,_Fld11684RRef [СчетСписанияБУ]
					,_Fld11685RRef [СчетСписанияНУ]
					,_Fld11682RRef [СубконтоБУ]
					,_Fld11683RRef [СубконтоНУ]
					,_Fld11686RRef [СобытиеРегл]
					From _Document458(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.СписаниеОС();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.СписаниеОС();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.СписаниеОС СтраницаПоНомеру(int Размер,int Номер)
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
					,_Fld11676RRef [Ответственный]
					,_Fld11674 [Комментарий]
					,_Fld11675RRef [Организация]
					,_Fld11677 [ОтражатьВБухгалтерскомУчете]
					,_Fld11678 [ОтражатьВНалоговомУчете]
					,_Fld11679 [ОтражатьВУправленческомУчете]
					,_Fld11680RRef [ПричинаСписания]
					,_Fld11681RRef [Событие]
					,_Fld11684RRef [СчетСписанияБУ]
					,_Fld11685RRef [СчетСписанияНУ]
					,_Fld11682RRef [СубконтоБУ]
					,_Fld11683RRef [СубконтоНУ]
					,_Fld11686RRef [СобытиеРегл]
					From _Document458(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.СписаниеОС();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.СписаниеОС();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.Комментарий = Читалка.GetString(4);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(6))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ОтражатьВУправленческомУчете = ((byte[])Читалка.GetValue(8))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static V82.ДокументыОбъект.СписаниеОС СоздатьЭлемент()
		{
			var Объект = new V82.ДокументыОбъект.СписаниеОС();
			Объект._ЭтоНовый = true;
			Объект.Ссылка = Guid.NewGuid();/*http://msdn.microsoft.com/ru-ru/library/aa379322(VS.85).aspx*/
			Объект.Комментарий = "";
			return Объект;
		}
	}
}