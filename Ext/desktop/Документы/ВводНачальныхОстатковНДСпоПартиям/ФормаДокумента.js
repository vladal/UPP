﻿Ext.define('Документы.ВводНачальныхОстатковНДСпоПартиям.ФормаДокумента',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:780px;height:484px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Ввод начальных остатков НДС по партиям',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			xtype: 'label',
			name: 'НадписьНомер',
			text: 'Номер:',
			style: 'position:absolute;left:8px;top:33px;width:88px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Номер',
			width: 80,
			height: 19,
			style: 'position:absolute;left:98px;top:33px;width:80px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьДата',
			text: 'от:',
			style: 'position:absolute;left:180px;top:33px;width:16px;height:19px;text-align:center;',
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
			style: 'position:absolute;left:198px;top:33px;width:120px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьКомментарий',
			text: 'Комментарий:',
			style: 'position:absolute;left:8px;top:429px;width:80px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Комментарий',
			width: 669,
			height: 19,
			style: 'position:absolute;left:103px;top:429px;width:669px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьОрганизация',
			text: 'Организация:',
			style: 'position:absolute;left:338px;top:33px;width:88px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-search-trigger',
			name: 'Организация',
			width: 346,
			height: 19,
			style: 'position:absolute;left:426px;top:33px;width:346px;height:19px;',
		},
		{
			id: 'ДанныеПоПартиям',
			xtype: 'grid',
			style: 'position:absolute;left:8px;top:101px;width:764px;height:104px;',
			height: 104,width: 764,
			columns:
			[
				{
					text:'№',
					width:'28',
					dataIndex:'НомерСтроки',
					flex:1,
				},
				{
					text:'Номенклатура',
					width:'1200',
					dataIndex:'Номенклатура',
					flex:1,
				},
				{
					text:'Характеристика номенклатуры',
					width:'100',
					dataIndex:'ХарактеристикаНоменклатуры',
					flex:1,
				},
				{
					text:'Серия номенклатуры',
					width:'100',
					dataIndex:'СерияНоменклатуры',
					flex:1,
				},
				{
					text:'Счет учета',
					width:'80',
					dataIndex:'СчетУчета',
					flex:1,
				},
				{
					text:'Партия',
					width:'1200',
					dataIndex:'Партия',
					flex:1,
				},
				{
					text:'Склад',
					width:'1200',
					dataIndex:'Склад',
					flex:1,
				},
				{
					text:'Количество',
					width:'1200',
					dataIndex:'Количество',
					flex:1,
				},
				{
					text:'Заказ покупателя',
					width:'100',
					dataIndex:'Заказ',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/ВводНачальныхОстатковНДСпоПартиям/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
					{
						name:'НомерСтроки',
					},
					{
						name:'Номенклатура',
					},
					{
						name:'ХарактеристикаНоменклатуры',
					},
					{
						name:'СерияНоменклатуры',
					},
					{
						name:'СчетУчета',
					},
					{
						name:'Партия',
					},
					{
						name:'Склад',
					},
					{
						name:'Количество',
					},
					{
						name:'Заказ',
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
						var грид = Ext.getCmp('ДанныеПоПартиям');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data;
						Ext.require(['Справочники.Банки.ФормаЭлементаСобытия'], function ()
						{
							var obj = Ext.create("Справочники.Банки.ФормаЭлементаСобытия");
							obj.ПередатьСсылку(ссылка);
						});
					}
				}
			},
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:459px;width:780px;height:25px;',
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
				},
			]
		},
		{
			xtype: 'tabpanel',
			style: 'position:absolute;left:8px;top:213px;width:764px;height:187px;',
			height: 187,width: 764,
			tabBar:{hidden:true},
			items:
			[
				{
					title:'Дополнительные сведения',
					items:
					[
		{
			id: 'ДанныеПоСФ',
			xtype: 'grid',
			style: 'position:absolute;left:0px;top:40px;width:764px;height:147px;',
			height: 147,width: 764,
			columns:
			[
				{
					text:'№',
					width:'28',
					dataIndex:'НомерСтроки',
					flex:1,
				},
				{
					text:'Счет-фактура',
					width:'1200',
					dataIndex:'СчетФактура',
					flex:1,
				},
				{
					text:'Вид ценности',
					width:'1200',
					dataIndex:'ВидЦенности',
					flex:1,
				},
				{
					text:'Счет учета НДС',
					width:'80',
					dataIndex:'СчетУчетаНДС',
					flex:1,
				},
				{
					text:'% НДС',
					width:'100',
					dataIndex:'СтавкаНДС',
					flex:1,
				},
				{
					text:'Количество',
					width:'1200',
					dataIndex:'Количество',
					flex:1,
				},
				{
					text:'Стоимость с НДС',
					width:'1200',
					dataIndex:'Стоимость',
					flex:1,
				},
				{
					text:'НДС',
					width:'1200',
					dataIndex:'НДС',
					flex:1,
				},
				{
					text:'НДС включен в стоимость',
					width:'60',
					dataIndex:'НДСВключенВСтоимость',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/ВводНачальныхОстатковНДСпоПартиям/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
					{
						name:'НомерСтроки',
					},
					{
						name:'СчетФактура',
					},
					{
						name:'ВидЦенности',
					},
					{
						name:'СчетУчетаНДС',
					},
					{
						name:'СтавкаНДС',
					},
					{
						name:'Количество',
					},
					{
						name:'Стоимость',
					},
					{
						name:'НДС',
					},
					{
						name:'НДСВключенВСтоимость',
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
						var грид = Ext.getCmp('ДанныеПоСФ');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data;
						Ext.require(['Справочники.Банки.ФормаЭлементаСобытия'], function ()
						{
							var obj = Ext.create("Справочники.Банки.ФормаЭлементаСобытия");
							obj.ПередатьСсылку(ссылка);
						});
					}
				}
			},
		},
		{
			xtype: 'fieldset',
			title: 'Данные по счетам-фактурам',
			style: 'position:absolute;left:0px;top:0px;width:764px;height:16px;',
		},
					]
				},
			]
		},
		{
			xtype: 'fieldset',
			title: 'Данные по партиям',
			style: 'position:absolute;left:8px;top:63px;width:764px;height:16px;',
		},
		{
			xtype: 'label',
			name: 'НадписьОтветственный',
			text: 'Ответственный:',
			style: 'position:absolute;left:8px;top:405px;width:86px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-clear-trigger',
			name: 'Ответственный',
			width: 669,
			height: 19,
			style: 'position:absolute;left:103px;top:405px;width:669px;height:19px;',
		},
		],
	}],
	dockedItems:
	[
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:0px;width:780px;height:25px;',
			dock: 'top',
			items:
			[
				'-',
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
				{
					text:'',
				},
				'-',
			]
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:8px;top:79px;width:764px;height:24px;',
			dock: 'top',
			items:
			[
			]
		},
	]
});