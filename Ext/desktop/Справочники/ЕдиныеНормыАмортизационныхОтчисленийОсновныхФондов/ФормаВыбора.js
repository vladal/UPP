﻿Ext.define('Справочники.ЕдиныеНормыАмортизационныхОтчисленийОсновныхФондов.ФормаВыбора',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:696px;height:321px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Единые нормы амортизационных отчислений на полное восстановление основных фондов',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			id: 'СправочникСписок',
			xtype: 'grid',
			style: 'position:absolute;left:186px;top:33px;width:502px;height:280px;',
			height: 280,width: 502,
			columns:
			[
				{
					text:'',
					width:'32',
					dataIndex:'Картинка',
					flex:1,
				},
				{
					text:'Код',
					width:'40',
					dataIndex:'Код',
					flex:1,
				},
				{
					text:'Наименование',
					width:'2200',
					dataIndex:'Наименование',
					flex:1,
				},
				{
					text:'Норма ам. отчислений (%)',
					width:'1400',
					dataIndex:'НормаАмортизационныхОтчислений',
					flex:1,
				},
				{
					text:'% от стоимости / 1000 км',
					width:'1400',
					dataIndex:'ПроцентОтСтоимостиМашины',
					flex:1,
				},
			],
			store:
			{
				data: Ext.create("Данные.Справочники.ЕдиныеНормыАмортизационныхОтчисленийОсновныхФондов").data,
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/ЕдиныеНормыАмортизационныхОтчисленийОсновныхФондов/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
					{
						name:'Картинка',
					},
					{
						name:'Код',
					},
					{
						name:'Наименование',
					},
					{
						name:'НормаАмортизационныхОтчислений',
					},
					{
						name:'ПроцентОтСтоимостиМашины',
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
						var грид = Ext.getCmp('СправочникСписок');
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
			id: 'СправочникДерево',
			xtype: 'grid',
			style: 'position:absolute;left:8px;top:33px;width:171px;height:280px;',
			height: 280,width: 171,
			columns:
			[
				{
					text:'Наименование',
					width:'3500',
					dataIndex:'Наименование',
					flex:1,
				},
			],
			store:
			{
				data: Ext.create("Данные.Справочники.ЕдиныеНормыАмортизационныхОтчисленийОсновныхФондов").data,
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/ЕдиныеНормыАмортизационныхОтчисленийОсновныхФондов/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
					{
						name:'Наименование',
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
						var грид = Ext.getCmp('СправочникДерево');
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
		],
	}],
	dockedItems:
	[
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:0px;width:696px;height:25px;',
			dock: 'top',
			items:
			[
				{
					text:'Выбрать',
				},
				'-',
			]
		},
	]
});