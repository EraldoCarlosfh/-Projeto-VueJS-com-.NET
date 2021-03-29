import{ http } from './config'

export default {    
    list:() =>{
        return http.get('Technical')        
    },
    save:(technicals) =>{
        return http.post('Technical', technicals)     
    },

    del:(id, technicals) =>{
        return http.delete(`Technical/${id}`, technicals)    
    },

    update: (id, technicals) => {
        return http.put(`Technical/${id}`, technicals)
    },    
}