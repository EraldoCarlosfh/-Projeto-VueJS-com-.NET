import{ http } from './config'

export default {    
    list:() =>{
        return http.get('Technical')        
    },
    save:(Technical) =>{
        return http.post('Technical',Technical)     
    },
    del:(id) =>{
        return http.del('Technical',{id})     
    },

    update: (technicals) => {
        return http.put('Technical',technicals )
    },
   
    
}