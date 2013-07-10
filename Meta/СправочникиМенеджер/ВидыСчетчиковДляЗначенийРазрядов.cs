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
	public partial class ВидыСчетчиковДляЗначенийРазрядов:СправочникМенеджер
	{
		
		public static СправочникиСсылка.ВидыСчетчиковДляЗначенийРазрядов НайтиПоСсылке(Guid _Ссылка)
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
					,_Fld954 [РазмерСчетчика]
					,_Fld955 [ВПределахОрганизации]
					,_Fld956 [ВПределахПодразделения]
					,_Fld957 [ВПределахНоменклатурнойГруппы]
					,_Fld958 [ВПределахНоменклатуры]
					,_Fld959 [НачальноеЗначение]
					,_Fld960 [КонечноеЗначение]
					From _Reference26(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new СправочникиСсылка.ВидыСчетчиковДляЗначенийРазрядов();
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
							Ссылка.РазмерСчетчика = Читалка.GetDecimal(6);
							Ссылка.ВПределахОрганизации = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ВПределахПодразделения = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ВПределахНоменклатурнойГруппы = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.ВПределахНоменклатуры = ((byte[])Читалка.GetValue(10))[0]==1;
							Ссылка.НачальноеЗначение = Читалка.GetDecimal(11);
							Ссылка.КонечноеЗначение = Читалка.GetDecimal(12);
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
		
		public static СправочникиСсылка.ВидыСчетчиковДляЗначенийРазрядов НайтиПоКоду(string Код)
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
					,_Fld954 [РазмерСчетчика]
					,_Fld955 [ВПределахОрганизации]
					,_Fld956 [ВПределахПодразделения]
					,_Fld957 [ВПределахНоменклатурнойГруппы]
					,_Fld958 [ВПределахНоменклатуры]
					,_Fld959 [НачальноеЗначение]
					,_Fld960 [КонечноеЗначение]
					From _Reference26(NOLOCK)
					Where _Code=@Код";
					Команда.Parameters.AddWithValue("Код", Код);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new СправочникиСсылка.ВидыСчетчиковДляЗначенийРазрядов();
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
							Ссылка.РазмерСчетчика = Читалка.GetDecimal(6);
							Ссылка.ВПределахОрганизации = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ВПределахПодразделения = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ВПределахНоменклатурнойГруппы = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.ВПределахНоменклатуры = ((byte[])Читалка.GetValue(10))[0]==1;
							Ссылка.НачальноеЗначение = Читалка.GetDecimal(11);
							Ссылка.КонечноеЗначение = Читалка.GetDecimal(12);
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
		
		public static СправочникиВыборка.ВидыСчетчиковДляЗначенийРазрядов Выбрать()
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
					,_Fld954 [РазмерСчетчика]
					,_Fld955 [ВПределахОрганизации]
					,_Fld956 [ВПределахПодразделения]
					,_Fld957 [ВПределахНоменклатурнойГруппы]
					,_Fld958 [ВПределахНоменклатуры]
					,_Fld959 [НачальноеЗначение]
					,_Fld960 [КонечноеЗначение]
					From _Reference26(NOLOCK) ";
					var Выборка = new V82.СправочникиВыборка.ВидыСчетчиковДляЗначенийРазрядов();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new СправочникиСсылка.ВидыСчетчиковДляЗначенийРазрядов();
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
							Ссылка.РазмерСчетчика = Читалка.GetDecimal(6);
							Ссылка.ВПределахОрганизации = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ВПределахПодразделения = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ВПределахНоменклатурнойГруппы = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.ВПределахНоменклатуры = ((byte[])Читалка.GetValue(10))[0]==1;
							Ссылка.НачальноеЗначение = Читалка.GetDecimal(11);
							Ссылка.КонечноеЗначение = Читалка.GetDecimal(12);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static СправочникиВыборка.ВидыСчетчиковДляЗначенийРазрядов ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
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
					,_Fld954 [РазмерСчетчика]
					,_Fld955 [ВПределахОрганизации]
					,_Fld956 [ВПределахПодразделения]
					,_Fld957 [ВПределахНоменклатурнойГруппы]
					,_Fld958 [ВПределахНоменклатуры]
					,_Fld959 [НачальноеЗначение]
					,_Fld960 [КонечноеЗначение]
					From _Reference26(NOLOCK)
					Where _IDRRef between @Мин and @Макс 
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.СправочникиВыборка.ВидыСчетчиковДляЗначенийРазрядов();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new СправочникиСсылка.ВидыСчетчиковДляЗначенийРазрядов();
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
							Ссылка.РазмерСчетчика = Читалка.GetDecimal(6);
							Ссылка.ВПределахОрганизации = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ВПределахПодразделения = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ВПределахНоменклатурнойГруппы = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.ВПределахНоменклатуры = ((byte[])Читалка.GetValue(10))[0]==1;
							Ссылка.НачальноеЗначение = Читалка.GetDecimal(11);
							Ссылка.КонечноеЗначение = Читалка.GetDecimal(12);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static СправочникиВыборка.ВидыСчетчиковДляЗначенийРазрядов ВыбратьПоКоду(int Первые,string Мин,string Макс)
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
					,_Fld954 [РазмерСчетчика]
					,_Fld955 [ВПределахОрганизации]
					,_Fld956 [ВПределахПодразделения]
					,_Fld957 [ВПределахНоменклатурнойГруппы]
					,_Fld958 [ВПределахНоменклатуры]
					,_Fld959 [НачальноеЗначение]
					,_Fld960 [КонечноеЗначение]
					From _Reference26(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.СправочникиВыборка.ВидыСчетчиковДляЗначенийРазрядов();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new СправочникиСсылка.ВидыСчетчиковДляЗначенийРазрядов();
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
							Ссылка.РазмерСчетчика = Читалка.GetDecimal(6);
							Ссылка.ВПределахОрганизации = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ВПределахПодразделения = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ВПределахНоменклатурнойГруппы = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.ВПределахНоменклатуры = ((byte[])Читалка.GetValue(10))[0]==1;
							Ссылка.НачальноеЗначение = Читалка.GetDecimal(11);
							Ссылка.КонечноеЗначение = Читалка.GetDecimal(12);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static СправочникиВыборка.ВидыСчетчиковДляЗначенийРазрядов ВыбратьПоНаименованию(int Первые,string Мин,string Макс)
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
					,_Fld954 [РазмерСчетчика]
					,_Fld955 [ВПределахОрганизации]
					,_Fld956 [ВПределахПодразделения]
					,_Fld957 [ВПределахНоменклатурнойГруппы]
					,_Fld958 [ВПределахНоменклатуры]
					,_Fld959 [НачальноеЗначение]
					,_Fld960 [КонечноеЗначение]
					From _Reference26(NOLOCK)
					Where _Description between @Мин and @Макс
					Order by _Description", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.СправочникиВыборка.ВидыСчетчиковДляЗначенийРазрядов();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new СправочникиСсылка.ВидыСчетчиковДляЗначенийРазрядов();
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
							Ссылка.РазмерСчетчика = Читалка.GetDecimal(6);
							Ссылка.ВПределахОрганизации = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ВПределахПодразделения = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ВПределахНоменклатурнойГруппы = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.ВПределахНоменклатуры = ((byte[])Читалка.GetValue(10))[0]==1;
							Ссылка.НачальноеЗначение = Читалка.GetDecimal(11);
							Ссылка.КонечноеЗначение = Читалка.GetDecimal(12);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static СправочникиВыборка.ВидыСчетчиковДляЗначенийРазрядов СтраницаПоСсылке(int Размер,int Номер)
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
					,_Fld954 [РазмерСчетчика]
					,_Fld955 [ВПределахОрганизации]
					,_Fld956 [ВПределахПодразделения]
					,_Fld957 [ВПределахНоменклатурнойГруппы]
					,_Fld958 [ВПределахНоменклатуры]
					,_Fld959 [НачальноеЗначение]
					,_Fld960 [КонечноеЗначение]
					From _Reference26(NOLOCK)";
					var Выборка = new V82.СправочникиВыборка.ВидыСчетчиковДляЗначенийРазрядов();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new СправочникиСсылка.ВидыСчетчиковДляЗначенийРазрядов();
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
							Ссылка.РазмерСчетчика = Читалка.GetDecimal(6);
							Ссылка.ВПределахОрганизации = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ВПределахПодразделения = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ВПределахНоменклатурнойГруппы = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.ВПределахНоменклатуры = ((byte[])Читалка.GetValue(10))[0]==1;
							Ссылка.НачальноеЗначение = Читалка.GetDecimal(11);
							Ссылка.КонечноеЗначение = Читалка.GetDecimal(12);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static СправочникиВыборка.ВидыСчетчиковДляЗначенийРазрядов СтраницаПоКоду(int Размер,int Номер)
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
					,_Fld954 [РазмерСчетчика]
					,_Fld955 [ВПределахОрганизации]
					,_Fld956 [ВПределахПодразделения]
					,_Fld957 [ВПределахНоменклатурнойГруппы]
					,_Fld958 [ВПределахНоменклатуры]
					,_Fld959 [НачальноеЗначение]
					,_Fld960 [КонечноеЗначение]
					From _Reference26(NOLOCK)";
					var Выборка = new V82.СправочникиВыборка.ВидыСчетчиковДляЗначенийРазрядов();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new СправочникиСсылка.ВидыСчетчиковДляЗначенийРазрядов();
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
							Ссылка.РазмерСчетчика = Читалка.GetDecimal(6);
							Ссылка.ВПределахОрганизации = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ВПределахПодразделения = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ВПределахНоменклатурнойГруппы = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.ВПределахНоменклатуры = ((byte[])Читалка.GetValue(10))[0]==1;
							Ссылка.НачальноеЗначение = Читалка.GetDecimal(11);
							Ссылка.КонечноеЗначение = Читалка.GetDecimal(12);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static СправочникиВыборка.ВидыСчетчиковДляЗначенийРазрядов СтраницаПоНаименованию(int Размер,int Номер)
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
					,_Fld954 [РазмерСчетчика]
					,_Fld955 [ВПределахОрганизации]
					,_Fld956 [ВПределахПодразделения]
					,_Fld957 [ВПределахНоменклатурнойГруппы]
					,_Fld958 [ВПределахНоменклатуры]
					,_Fld959 [НачальноеЗначение]
					,_Fld960 [КонечноеЗначение]
					From _Reference26(NOLOCK)";
					var Выборка = new V82.СправочникиВыборка.ВидыСчетчиковДляЗначенийРазрядов();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new СправочникиСсылка.ВидыСчетчиковДляЗначенийРазрядов();
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
							Ссылка.РазмерСчетчика = Читалка.GetDecimal(6);
							Ссылка.ВПределахОрганизации = ((byte[])Читалка.GetValue(7))[0]==1;
							Ссылка.ВПределахПодразделения = ((byte[])Читалка.GetValue(8))[0]==1;
							Ссылка.ВПределахНоменклатурнойГруппы = ((byte[])Читалка.GetValue(9))[0]==1;
							Ссылка.ВПределахНоменклатуры = ((byte[])Читалка.GetValue(10))[0]==1;
							Ссылка.НачальноеЗначение = Читалка.GetDecimal(11);
							Ссылка.КонечноеЗначение = Читалка.GetDecimal(12);
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static V82.СправочникиОбъект.ВидыСчетчиковДляЗначенийРазрядов СоздатьЭлемент()
		{
			var Объект = new V82.СправочникиОбъект.ВидыСчетчиковДляЗначенийРазрядов();
			Объект._ЭтоНовый = true;
			Объект.Ссылка = Guid.NewGuid();/*http://msdn.microsoft.com/ru-ru/library/aa379322(VS.85).aspx*/
			return Объект;
		}
	}
}