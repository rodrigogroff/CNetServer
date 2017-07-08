// JavaScript Document
function mascara(o,f){
    v_obj=o;
    v_fun=f;
    setTimeout("execmascara()",1);
}

function execmascara(){
    v_obj.value=v_fun(v_obj.value);
}
function soNumeros(v){
    return v.replace(/\D/g,"");
}

function telefonefunc(v){
    v=v.replace(/\D/g,"");              //Remove tudo o que não é dígito
    v=v.replace(/^(\d\d)(\d)/g,"($1) $2"); //Coloca parênteses em volta dos dois primeiros dígitos
    v=v.replace(/(\d{4})(\d)/,"$1-$2");    //Coloca hífen entre o quarto e o quinto dígitos
    return v;
}

function cpfunc(v){
    v=v.replace(/\D/g,"");                    //Remove tudo o que não é dígito
    v=v.replace(/(\d{3})(\d)/,"$1.$2");       //Coloca um ponto entre o terceiro e o quarto dígitos
    v=v.replace(/(\d{3})(\d)/,"$1.$2");       //Coloca um ponto entre o terceiro e o quarto dígitos
                                             //de novo (para o segundo bloco de números)
    v=v.replace(/(\d{3})(\d{1,2})$/,"$1-$2"); //Coloca um hífen entre o terceiro e o quarto dígitos
    return v;
}

function cepfunc(v){
    v=v.replace(/D/g,"");                //Remove tudo o que não é dígito
    v=v.replace(/^(\d{5})(\d)/,"$1-$2"); //Esse é tão fácil que não merece explicações
    return v;
}

function cnpjfunc(v){
    v=v.replace(/\D/g,"");                           //Remove tudo o que não é dígito
    v=v.replace(/^(\d{2})(\d)/,"$1.$2");             //Coloca ponto entre o segundo e o terceiro dígitos
    v=v.replace(/^(\d{2})\.(\d{3})(\d)/,"$1.$2.$3"); //Coloca ponto entre o quinto e o sexto dígitos
    v=v.replace(/\.(\d{3})(\d)/,".$1/$2");           //Coloca uma barra entre o oitavo e o nono dígitos
    v=v.replace(/(\d{4})(\d)/,"$1-$2");              //Coloca um hífen depois do bloco de quatro dígitos
    return v;
	
}
function cmc7func(v)
{
     v=v.replace(/\D/g,"");                    
    v=v.replace(/(\d{8})(\d)/,"$1   $2");      
    v=v.replace(/(\d{10})(\d)/,"$1   $2");     
    v=v.replace(/(\d{12})(\d)/,"$1 ");       
    return v;
}
function cardnumberfunc(v)
{
     v=v.replace(/\D/g,"");                    
    v=v.replace(/^(\d{6})(\d)/,"$1.$2");             //Coloca ponto entre o segundo e o terceiro dígitos
    v=v.replace(/^(\d{6})\.(\d{6})(\d)/,"$1.$2.$3");      
	 v=v.replace(/^(\d{6})\.(\d{6})\.(\d{4})(\d)/,"$1.$2.$3.$4");      
    return v;
}

function currfunc(v){
    v=v.replace(/\D/g,"");                           //Remove tudo o que não é dígito
    var xx=v.toString()
    var strnum=xx.length;
    // remove zeros
    return (soValorC(v,2));
//		return v;
}
function soValorC(valor,dec){ 
  // parte decimal e inteira do n?mero 
  intstr = ''; 
  decstr = ''; 
  temp_valor = ''; 
  
  // remove todos os caracteres que n?o s?o v?lidos 
  var validos = "0123456789"; 
  var numero_ok = ''; 
  for(i=0;i<valor.length;i++){ 
    if(validos.indexOf(valor.substr(i,1)) != -1) { 
          temp_valor += valor.substr(i,1); 
    } 
  } 
  
  // separa parte decimal de parte inteira 
  if (temp_valor.length == 0) { 
    intstr = "0"; 
    // concatena zeros 
    for (i = 0; i < dec;i++) { 
      decstr += "0"; 
    } 
  } 
  else if (temp_valor.length == 1) { 
    intstr = "0"; 
    // concatena zeros 
    for (i = 0; i < (dec - 1);i++) { 
      decstr += "0"; 
    } 
    decstr += temp_valor; 
  } 
  else if (temp_valor.length <= dec) { 
    intstr = "0" 
    decstr = temp_valor; 
    for (i = temp_valor.length; i < dec; i++) { 
      decstr += "0"; 
    } 
  } 
  else { 
    intstr = temp_valor.substring(0,(temp_valor.length - dec)); 
    decstr = temp_valor.substring((temp_valor.length - dec),temp_valor.length); 
  } 
  
  // remove zeros a esquerda da parte inteira 
  temp_valor = intstr; 
  intstr = ''; 
  primeiro_valor = false; 
  for(i=0;i<temp_valor.length;i++){ 
    if (primeiro_valor == false) { 
      if (temp_valor.substr(i,1) != "0") { 
        primeiro_valor = true; 
        intstr += temp_valor.substr(i,1); 
      }      
    } 
    else { 

      intstr += temp_valor.substr(i,1); 
    }    
  } 
  if(intstr.length == 0) { 
    intstr = "0"; 
  } 
  
  // adiciona "." a cada 3 algarismos (partindo da direita para esquerda) 
  temp_valor = intstr; 
  intstr = ''; 
  ponto = 0; 
  for (i = temp_valor.length; i > 0;i--) { 
    if ( ((ponto % 3) == 0) && 
          (ponto != 0) ){ 
      intstr = temp_valor.substr(i -1,1) + "." + intstr; 
    } 
    else { 
      intstr = temp_valor.substr(i -1,1) + intstr; 
    } 
    ponto++; 
  } 
  
  // concatena v?rgula entre parte inteira e decimal 
  temp_valor = intstr + "," + decstr; 
  
  // retorna valor concatenado com v?rgula 
  return temp_valor; 
} 

function formatCurrency(num) {
num = num.toString().replace(/\$|\,/g,'');
num = num.replace(/\D/g,"");
if(isNaN(num))
num = "0";
sign = (num == (num = Math.abs(num)));
num = Math.floor(num*100+0.50000000001);
cents = num%100;
num = Math.floor(num/100).toString();
if(cents<10)
cents = "0" + cents;
for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
num = num.substring(0,num.length-(4*i+3))+'.'+
num.substring(num.length-(4*i+3));
return (((sign)?'':'-') + '$' + num + ',' + cents);
}


function DataHora(evento, objeto){
	var keypress=(window.event)?event.keyCode:evento.which;
	campo = eval (objeto);
	if (campo.value == '00/00/0000')
	{
		campo.value=""
	}

	caracteres = '0123456789';
	separacao1 = '/';
	conjunto1 = 2;
	conjunto2 = 5;
	conjunto3 = 10;
	if ((caracteres.search(String.fromCharCode (keypress))!=-1) && campo.value.length < (19))
	{
		if (campo.value.length == conjunto1 )
		campo.value = campo.value + separacao1;
		else if (campo.value.length == conjunto2)
		campo.value = campo.value + separacao1;
	}
	else
		event.returnValue = false;
}

