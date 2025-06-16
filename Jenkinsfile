pipeline {
    agent any

    environment {
        DOTNET_VERSION = '8.0'
        //DOCKER_IMAGE = "pashi44/onpmysql:latest'
        //DOCKER_CREDENTIALS_ID = 'dockerhub-creds' // from Jenkins credentials
    }

    stages {

        stage('Checkout') {
            steps {
                git branch: 'dev', url: 'https://github.com/pashi44/onpmysql.git'
            }
        }

        stage('Install .NET SDK') {
            steps {
		sh 	'''
            		curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --version $DOTNET_VERSION --install-dir $HOME/dotnet
            		echo "## PATH EXPORT ##"
           		 export PATH=$HOME/dotnet:$PATH
        		'''
                sh 'chmod +x dotnet-install.sh'
                sh './dotnet-install.sh --version $DOTNET_VERSION --install-dir $HOME/dotnet'
         //       env.PATH = "${env.HOME}/dotnet:${env.PATH}"
            }
        }

        stage('Restore') {
            steps {
                sh '$HOME/dotnet/dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh '$HOME/dotnet/dotnet build --configuration Release'


 }
        }

        stage('Publish') {
            steps {
                sh '$HOME/dotnet/dotnet publish -c Release -o ./publish'
            }
        }

        //stage('Build Docker Image') {
          //  steps {
            //    sh 'docker build -t $DOCKER_IMAGE .'
            //}
        //}
//
  //      stage('Push Docker Image') {
     //       steps {
     //          withCredentials([usernamePassword(
    //                credentialsId: "${DOCKER_CREDENTIALS_ID}",
      //              usernameVariable: 'DOCKER_USER',
          //          passwordVariable: 'DOCKER_PASS'
        //        )]) {
            //        sh '''
              //          echo "$DOCKER_PASS" | docker login -u "$DOCKER_USER" --password-stdin
                //        docker push $DOCKER_IMAGE
                  //  '''
                //}
           // }
        //}

       // stage('Deploy on  Pi') {
         //   steps {
           //     sshagent (credentials: ['pi-ssh-creds']) {
             //       sh '''
               //         ssh -o StrictHostKeyChecking=no pi@<PI_IP_ADDRESS> <<EOF
                 //       docker pull $DOCKER_IMAGE
                   //     docker stop onpmysql || true
                     //   docker rm onpmysql || true
                       // docker run -d --name onpmysql -p 80:80 $DOCKER_IMAGE
                        //EOF
                    //'''
                //}
            //}
        //}
    }

    post {
        failure {
            echo 'Build or deployment failed.'
        }
        success {
            echo 'App built, containerized, pushed, and deployed successfully!'
        }
    }
}
