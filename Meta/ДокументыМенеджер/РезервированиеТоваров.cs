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
	public partial class РезервированиеТоваров:ДокументМенеджер
	{
		
		public static ДокументыСсылка.РезервированиеТоваров НайтиПоСсылке(Guid _Ссылка)
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
					,_Fld11328_TYPE [Заказ_Тип],_Fld11328_RRRef [Заказ],_Fld11328_RTRef [Заказ_Вид]
					,_Fld11329RRef [ВидОперации]
					,_Fld11330 [Комментарий]
					,_Fld11331RRef [Подразделение]
					,_Fld11332RRef [Контрагент]
					,_Fld11333RRef [Ответственный]
					,_Fld11334RRef [Организация]
					,_Fld11335 [ОтражатьВБухгалтерскомУчете]
					,_Fld11336 [ОтражатьВНалоговомУчете]
					From _Document446(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РезервированиеТоваров();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийРезервированиеТоваров.ПустаяСсылка.Получить((byte[])Читалка.GetValue(6));
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(13))[0]==1;
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
		
		public static ДокументыСсылка.РезервированиеТоваров НайтиПоНомеру(string Номер)
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
					,_Fld11328_TYPE [Заказ_Тип],_Fld11328_RRRef [Заказ],_Fld11328_RTRef [Заказ_Вид]
					,_Fld11329RRef [ВидОперации]
					,_Fld11330 [Комментарий]
					,_Fld11331RRef [Подразделение]
					,_Fld11332RRef [Контрагент]
					,_Fld11333RRef [Ответственный]
					,_Fld11334RRef [Организация]
					,_Fld11335 [ОтражатьВБухгалтерскомУчете]
					,_Fld11336 [ОтражатьВНалоговомУчете]
					From _Document446(NOLOCK)
					Where _Number = @Номер";
					Команда.Parameters.AddWithValue("Номер", Номер);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РезервированиеТоваров();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийРезервированиеТоваров.ПустаяСсылка.Получить((byte[])Читалка.GetValue(6));
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(13))[0]==1;
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
		
		public static ДокументыВыборка.РезервированиеТоваров Выбрать()
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
					,_Fld11328_TYPE [Заказ_Тип],_Fld11328_RRRef [Заказ],_Fld11328_RTRef [Заказ_Вид]
					,_Fld11329RRef [ВидОперации]
					,_Fld11330 [Комментарий]
					,_Fld11331RRef [Подразделение]
					,_Fld11332RRef [Контрагент]
					,_Fld11333RRef [Ответственный]
					,_Fld11334RRef [Организация]
					,_Fld11335 [ОтражатьВБухгалтерскомУчете]
					,_Fld11336 [ОтражатьВНалоговомУчете]
					From _Document446(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.РезервированиеТоваров();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РезервированиеТоваров();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийРезервированиеТоваров.ПустаяСсылка.Получить((byte[])Читалка.GetValue(6));
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(13))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.РезервированиеТоваров ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
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
					,_Fld11328_TYPE [Заказ_Тип],_Fld11328_RRRef [Заказ],_Fld11328_RTRef [Заказ_Вид]
					,_Fld11329RRef [ВидОперации]
					,_Fld11330 [Комментарий]
					,_Fld11331RRef [Подразделение]
					,_Fld11332RRef [Контрагент]
					,_Fld11333RRef [Ответственный]
					,_Fld11334RRef [Организация]
					,_Fld11335 [ОтражатьВБухгалтерскомУчете]
					,_Fld11336 [ОтражатьВНалоговомУчете]
					From _Document446(NOLOCK)
					Where _IDRRef between @Мин and @Макс
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.РезервированиеТоваров();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РезервированиеТоваров();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийРезервированиеТоваров.ПустаяСсылка.Получить((byte[])Читалка.GetValue(6));
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(13))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.РезервированиеТоваров ВыбратьПоНомеру(int Первые,string Мин,string Макс)
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
					,_Fld11328_TYPE [Заказ_Тип],_Fld11328_RRRef [Заказ],_Fld11328_RTRef [Заказ_Вид]
					,_Fld11329RRef [ВидОперации]
					,_Fld11330 [Комментарий]
					,_Fld11331RRef [Подразделение]
					,_Fld11332RRef [Контрагент]
					,_Fld11333RRef [Ответственный]
					,_Fld11334RRef [Организация]
					,_Fld11335 [ОтражатьВБухгалтерскомУчете]
					,_Fld11336 [ОтражатьВНалоговомУчете]
					From _Document446(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.РезервированиеТоваров();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РезервированиеТоваров();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийРезервированиеТоваров.ПустаяСсылка.Получить((byte[])Читалка.GetValue(6));
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(13))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.РезервированиеТоваров СтраницаПоСсылке(int Размер,int Номер)
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
					,_Fld11328_TYPE [Заказ_Тип],_Fld11328_RRRef [Заказ],_Fld11328_RTRef [Заказ_Вид]
					,_Fld11329RRef [ВидОперации]
					,_Fld11330 [Комментарий]
					,_Fld11331RRef [Подразделение]
					,_Fld11332RRef [Контрагент]
					,_Fld11333RRef [Ответственный]
					,_Fld11334RRef [Организация]
					,_Fld11335 [ОтражатьВБухгалтерскомУчете]
					,_Fld11336 [ОтражатьВНалоговомУчете]
					From _Document446(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.РезервированиеТоваров();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РезервированиеТоваров();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийРезервированиеТоваров.ПустаяСсылка.Получить((byte[])Читалка.GetValue(6));
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(13))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.РезервированиеТоваров СтраницаПоНомеру(int Размер,int Номер)
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
					,_Fld11328_TYPE [Заказ_Тип],_Fld11328_RRRef [Заказ],_Fld11328_RTRef [Заказ_Вид]
					,_Fld11329RRef [ВидОперации]
					,_Fld11330 [Комментарий]
					,_Fld11331RRef [Подразделение]
					,_Fld11332RRef [Контрагент]
					,_Fld11333RRef [Ответственный]
					,_Fld11334RRef [Организация]
					,_Fld11335 [ОтражатьВБухгалтерскомУчете]
					,_Fld11336 [ОтражатьВНалоговомУчете]
					From _Document446(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.РезервированиеТоваров();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.РезервированиеТоваров();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийРезервированиеТоваров.ПустаяСсылка.Получить((byte[])Читалка.GetValue(6));
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.ОтражатьВБухгалтерскомУчете = ((byte[])Читалка.GetValue(12))[0]==1;
							Ссылка.ОтражатьВНалоговомУчете = ((byte[])Читалка.GetValue(13))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static V82.ДокументыОбъект.РезервированиеТоваров СоздатьЭлемент()
		{
			var Объект = new V82.ДокументыОбъект.РезервированиеТоваров();
			Объект._ЭтоНовый = true;
			Объект.Ссылка = Guid.NewGuid();/*http://msdn.microsoft.com/ru-ru/library/aa379322(VS.85).aspx*/
			Объект.Комментарий = "";
			Объект.ВидОперации = V82.Перечисления/*Ссылка*/.ВидыОперацийРезервированиеТоваров.ПустаяСсылка;
			return Объект;
		}
	}
}