use lojadb;
------------ inicio dados de Funcionarios --------------------------
insert into funcionarios ( id_funcionario   
						  ,nome_funcionario 
						  ,cargo_funcionario
						  ,rg_funcionario  
						  ,cpf_funcionario
						 )
		values 
				( 10, 'La�s Ingrid'          ,'Atendente','4.165.465','101.030.123-01') ,
				( 11, 'Renan Agusto de Moura','Gerente'  ,'9.265.966','201.040.133-04') ,
				( 12, 'Italo de Brito Freire','Atendente','1.237.568','301.050.133-13')
			  ;

--select*from funcionarios;
--delete from funcionarios ;
------------ fim dados de Funcionarios -----------------------------

------------ inicio dados de cliente -----------------------------
insert into clientes (   id_cliente            
					    ,nome_cliente      
					    ,cpf_cliente       
					    ,rg_cliente        
					    ,tel_cliente       
					    ,logradouro_cliente
					    ,email_cliente 
					  )    
		values
			  ( 1, 'Josinaldo de S� do Santos'    , '351.710.199-23', '9.968.715', '(81)98824-0540', 'Rua Leandro Barreto 355, Jardim S�o Paulo', 'josi_sa@gmail.com'),
			  ( 2, 'Renilson da Costa de Lima'    , '495.915.591-90', '9.866.731', '(81)99548-1413', 'Rua Carlos Alberto Barbosa 212, Rio Doce' , 'renilson_lima@hotmail.com'),
			  ( 3, 'Pedro Victor Clemente Pedrosa', '185.687.094-06', '9.105.489', '(81)99963-8862', 'Rua da Soledade, 123 Boa Vista'           , 'pevic_pedosa@gmail.com')
			  ;


--select*from clientes;
--delete from clientes;

------------ fim dados de cliente -----------------------------

------------ Inicio dados de Produto -----------------------------
insert into produtos (id_produto,nome_produto,marca_produto,tipo_produto,valor_produto,estoque_produto,detalhe_produto) values
			 (100,'Guitarra Strato Fender American Special Sunburst'     ,'Fender'   ,'Pau e Corda',5640.00  ,5, 'corpo em Alder, bra�o em maple C e 3 captadores Texas Especial , chave com 5 posi��es permite regular sua sonoridade com precis�o, acabamento refinado, com headstock ao estilo anos 70 e tarraxas standard cast'   )
			,(101,'Guitarra Les Paul Gibson Supreme'                     ,'Gibson'   ,'Pau e Corda',13413.00 ,3, 'tampo e fundo em AAAA Figured Maple, bra�o em Mogno, escala em Richlite com 22 trastes, captadores Humbucker 490R e 498T e ferragens douradas. Esse modelo ainda possui ponte Tune-O-Matic, Stopbar Tailpiece, tarraxas Keystone Grovers, 2 controles de volume, 2 de tone e chave seletora de 3 posi��es' )
			,(102,'Piano Digital Korg SP 280 88 Teclas'                  ,'Korg'     ,'Tecla'      ,6006.85 ,4,'Toque de sele��o: Luz, Normal, pesado; - Pitch: Trans, ajuste fino; - Temperamento: 9 tipos; - Gera��o de som: Sistema est�reo de Piano; - Sons: 30 Total (10 x 3 bancos); Piano ac�stico x 5')
			,(103,'Bateria Ac�stica Vogga 8 Pe�as - Vogga Talent VPD920 ','Vogga'    ,'percu��o'  ,2097.60 ,5,' Possui bumbo de 20�, sendo constru�da em Poplar (6 folhas/ 7mm), al�m de trazer ferragens duplas. Possui configura��o cl�ssica com 2 tons, surdo de ch�o, bumbo e caixa'  )
			,(104,'Flauta Doce Germ�nica YRN-302BII'                     ,'Yamaha'   ,'sopro'      ,62.00,6,'Flauta doce, transl�cida e colorida que torna a pr�tica mais divertida para os alunos. Feita de resina ABS, oferece a mesma qualidade que as outras flautas Yamaha.' )
			,(105, 'Clarinete Michael WCLM48 Soprano Si bemol '          ,'Michael'  ,'sopro'      ,1347.34,2,'A WCLM48 possui sapatilhas italianas L. Pisoni, feitas em feltro tran�ado, bastante resistentes, para melhor veda��o das chamin�s (furos). Al�m disso, a pele natural de �tima qualidade � imperme�vel, sem deixar que a umidade penetra nas partes internas da sapatilha.')
			,(106,'Acordeon Michael ACM8007 80 Baixos'                   ,'Michael'  ,'aerofone'   ,5362.85,3,'� uma sanfona constru�da com mat�rias-primas selecionadas! O ACM8007 possui palhetas de a�o inoxid�vel, v�lvulas de couro e limitadores de v�lvula em cobre que valorizam ainda mais o volume. Possui ainda cantoneiras externas com fole de metal resistentes e traz estrutura com madeira de lei que proporciona maior durabilidade.')
			,(107,'Viol�o Madrid MD 100 Ac�stico Cl�ssico'               ,'Madri'    ,'pau e corda',369.55   ,6,'O MD 100 � um viol�o cl�ssico ac�stico que possui um som bem acentuado e cordas de nylon, o que o torna perfeito para pessoas que est�o come�ando a tocar.')
			,(108, 'Contrabaixo Strinberg 4 Cordas Ativo El�trico'       ,'Strinberg','pau e corda',1225.50,3,'O CLB 24A possui circuito ativo e controles precisos de equaliza��o e balanceamento')
			;

--delete from produtos
------------ Fim dados de Produto -----------------------------

------------ Inicio dados de Forma de Pagamento -----------------------------
insert into formapag (
						 id_formapag  
						,tipo_formapag
					  )
	values  (1,'Esp�cie')
           ,(2,'Cart�o')
		   ,(3,'Cheque')
		   ;

--delete from formapag;
------------ Fim dados de Forma de Pagamento -----------------------------
