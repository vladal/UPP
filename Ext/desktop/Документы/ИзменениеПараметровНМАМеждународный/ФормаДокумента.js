﻿Ext.require(['Данные.Документы.ИзменениеПараметровНМАМеждународный'], function () 
{
	Ext.define('Документы.ИзменениеПараметровНМАМеждународный.ФормаДокумента',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:651px;height:402px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	resizable: false,
	title: '',
	
	layout: {type: "fit",align: "stretch"},
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			xtype: 'label',
			name: 'Надпись1',
			text: 'Номер:',
			style: 'position:absolute;left:8px;top:33px;width:84px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Номер',
			width: 80,
			height: 19,
			style: 'position:absolute;left:94px;top:33px;width:80px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись2',
			text: 'от:',
			style: 'position:absolute;left:176px;top:33px;width:16px;height:19px;text-align:left;',
		},
		{
			xtype: 'datefield',
			hideLabel: true,
			disabled: false,
			value: 0,
			format: 'd.m.Y',
			name: 'Дата',
			width: 120,
			height: 19,
			style: 'position:absolute;left:194px;top:33px;width:120px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись3',
			text: 'Организация:',
			style: 'position:absolute;left:8px;top:57px;width:84px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-search-trigger',
			name: 'Организация.Представление',
			width: 220,
			height: 19,
			Хранилище:'Ссылка',
			style: 'position:absolute;left:94px;top:57px;width:220px;height:19px;',
			onTriggerClick : function(ЭтотОбъект)
			{
				var СтрокаЗнч = ЭтотОбъект.target.className;
				var Элемент = this.up('window');
				var Окно = Ext.getCmp(Элемент.getId());
				var Ссылка = Окно.Хранилище;
				if (СтрокаЗнч.indexOf("-select-") != -1)
				{
					Ext.require(['Документы.ИзменениеПараметровНМАМеждународный.ФормаДокументаСобытия'], function ()
					{
						var объект = Ext.create("Документы.ИзменениеПараметровНМАМеждународный.ФормаДокументаСобытия");
						объект.ПередатьСсылку(Ссылка);
					});
				};
				if (СтрокаЗнч.indexOf("-clear-") != -1)
				{
					alert('clear');
				};
				if (СтрокаЗнч.indexOf("-search-") != -1)
				{
					Ext.require(['Документы.ИзменениеПараметровНМАМеждународный.ФормаДокументаСобытия'], function ()
					{
						var объект = Ext.create("Документы.ИзменениеПараметровНМАМеждународный.ФормаДокументаСобытия");
						объект.ПередатьСсылку(Ссылка);
					});
				};
			},
		},
		{
			xtype: 'label',
			name: 'Надпись4',
			text: 'Комментарий:',
			style: 'position:absolute;left:8px;top:350px;width:84px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Комментарий',
			width: 549,
			height: 19,
			style: 'position:absolute;left:94px;top:350px;width:549px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись5',
			text: 'Ответственный:',
			style: 'position:absolute;left:336px;top:57px;width:84px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-clear-trigger',
			trigger3Cls: 'x-form-search-trigger',
			name: 'Ответственный.Представление',
			width: 220,
			height: 19,
			Хранилище:'Ссылка',
			style: 'position:absolute;left:423px;top:57px;width:220px;height:19px;',
			onTriggerClick : function(ЭтотОбъект)
			{
				var СтрокаЗнч = ЭтотОбъект.target.className;
				var Элемент = this.up('window');
				var Окно = Ext.getCmp(Элемент.getId());
				var Ссылка = Окно.Хранилище;
				if (СтрокаЗнч.indexOf("-select-") != -1)
				{
					Ext.require(['Документы.ИзменениеПараметровНМАМеждународный.ФормаДокументаСобытия'], function ()
					{
						var объект = Ext.create("Документы.ИзменениеПараметровНМАМеждународный.ФормаДокументаСобытия");
						объект.ПередатьСсылку(Ссылка);
					});
				};
				if (СтрокаЗнч.indexOf("-clear-") != -1)
				{
					alert('clear');
				};
				if (СтрокаЗнч.indexOf("-search-") != -1)
				{
					Ext.require(['Документы.ИзменениеПараметровНМАМеждународный.ФормаДокументаСобытия'], function ()
					{
						var объект = Ext.create("Документы.ИзменениеПараметровНМАМеждународный.ФормаДокументаСобытия");
						объект.ПередатьСсылку(Ссылка);
					});
				};
			},
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:8px;top:100px;width:635px;height:24px;',
			items:
			[
			]
		},
		{
			id: 'НематериальныеАктивы',
			xtype: 'grid',
			style: 'position:absolute;left:8px;top:120px;width:635px;height:220px;',
			height: 220,width: 635,
			columns:
			[
				{
					text:'№',
					width:'28',
					dataIndex:'НомерСтроки',
					flex:1,
				},
				{
					text:'НМА',
					width:'180',
					dataIndex:'НематериальныйАктив',
					flex:1,
				},
				{
					text:'Начислять амортизацию',
					width:'60',
					dataIndex:'НачислятьАмортизацию',
					flex:1,
				},
				{
					text:'Начислять амортизацию (новый)',
					width:'60',
					dataIndex:'НачислятьАмортизациюНов',
					flex:1,
				},
				{
					text:'Срок полезного использования',
					width:'80',
					dataIndex:'СрокПолезногоИспользования',
					flex:1,
				},
				{
					text:'Срок полезного использования (новый)',
					width:'80',
					dataIndex:'СрокПолезногоИспользованияНов',
					flex:1,
				},
				{
					text:'Метод начисления амортизации',
					width:'120',
					dataIndex:'МетодНачисленияАмортизации',
					flex:1,
				},
				{
					text:'Метод начисления амортизации (новый)',
					width:'120',
					dataIndex:'МетодНачисленияАмортизацииНов',
					flex:1,
				},
				{
					text:'Коэффициент ускорения',
					width:'100',
					dataIndex:'КоэффициентУскорения',
					flex:1,
				},
				{
					text:'Коэффициент ускорения (новый)',
					width:'100',
					dataIndex:'КоэффициентУскоренияНов',
					flex:1,
				},
				{
					text:'Предполагаемый объем продукции',
					width:'100',
					dataIndex:'ПредполагаемыйОбъемПродукции',
					flex:1,
				},
				{
					text:'Предполагаемый объем продукции (новый)',
					width:'100',
					dataIndex:'ПредполагаемыйОбъемПродукцииНов',
					flex:1,
				},
				{
					text:'Счет затрат',
					width:'80',
					dataIndex:'СчетЗатрат',
					flex:1,
				},
				{
					text:'Счет затрат (новый)',
					width:'80',
					dataIndex:'СчетЗатратНов',
					flex:1,
				},
				{
					text:'Субконто 1',
					width:'120',
					dataIndex:'Субконто1',
					flex:1,
				},
				{
					text:'Субконто 1 (новое)',
					width:'120',
					dataIndex:'Субконто1Нов',
					flex:1,
				},
				{
					text:'Субконто 2',
					width:'120',
					dataIndex:'Субконто2',
					flex:1,
				},
				{
					text:'Субконто 2 (новое)',
					width:'120',
					dataIndex:'Субконто2Нов',
					flex:1,
				},
				{
					text:'Субконто 3',
					width:'120',
					dataIndex:'Субконто3',
					flex:1,
				},
				{
					text:'Субконто 3 (новое)',
					width:'120',
					dataIndex:'Субконто3Нов',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/ИзменениеПараметровНМАМеждународный/ВыбратьПоСсылке/100', timeout: 200},
				fields:
				[
					{
						name:'Ссылка',
					},
					{
						name:'НомерСтроки',
					},
					{
						name:'НематериальныйАктив',
					},
					{
						name:'НачислятьАмортизацию',
					},
					{
						name:'НачислятьАмортизациюНов',
					},
					{
						name:'СрокПолезногоИспользования',
					},
					{
						name:'СрокПолезногоИспользованияНов',
					},
					{
						name:'МетодНачисленияАмортизации',
					},
					{
						name:'МетодНачисленияАмортизацииНов',
					},
					{
						name:'КоэффициентУскорения',
					},
					{
						name:'КоэффициентУскоренияНов',
					},
					{
						name:'ПредполагаемыйОбъемПродукции',
					},
					{
						name:'ПредполагаемыйОбъемПродукцииНов',
					},
					{
						name:'СчетЗатрат',
					},
					{
						name:'СчетЗатратНов',
					},
					{
						name:'Субконто1',
					},
					{
						name:'Субконто1Нов',
					},
					{
						name:'Субконто2',
					},
					{
						name:'Субконто2Нов',
					},
					{
						name:'Субконто3',
					},
					{
						name:'Субконто3Нов',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('НематериальныеАктивы');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data.Ссылка;
						var Хранилище = грид.store;
						var стрЗнач = Хранилище.findRecord('Ссылка', ссылка).data;
						Ext.require(['Справочники.ИзменениеПараметровНМАМеждународный.ФормаДокументаСобытия'], function ()
						{
							var obj = Ext.create("Справочники.ИзменениеПараметровНМАМеждународный.ФормаДокументаСобытия");
							obj.ПередатьСсылку(стрЗнач);
						});
					}
				}
			},
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:0px;width:651px;height:25px;',
			items:
			[
				{
					xtype: 'splitbutton',
					text:'',
					menu: [
				{
					text:'Движения документа по регистрам',
				},
				{
					text:'',
				},
				'-',
					]
				},
				'-',
				{
					text:'',
				},
				{
					text:'',
				},
			]
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:377px;width:651px;height:25px;',
			items:
			[
				{
					xtype: 'tbfill'
				},
				{
					text:'Печать',
				},
				'-',
				{
					text:'OK',
				},
				'-',
				{
					text:'Записать',
				},
				'-',
				{
					text:'Закрыть',
					handler: function () {this.up('window').close();},
				},
			]
		},
		{
			xtype: 'fieldset',
			title: 'Нематериальные активы',
			style: 'position:absolute;left:8px;top:84px;width:635px;height:16px;',
		},
		],
	}],
	dockedItems:
	[
	]
	});
});